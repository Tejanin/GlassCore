using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using GlassCoreAPI.DTOs;
using GlassCoreAPI.Models;


namespace GlassCoreAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
  
   
    public class UsuariosController : ApiController
    {
        private GlassCoreEntities db = new GlassCoreEntities();

        // GET: api/Usuarios

        [HttpGet]
        public List<ppFiltrarUsuarios_Result> GetUsuarios(string Ordenamiento = null, string Rol = null, string Estado = null)
        {
            var usuarios = db.ppFiltrarUsuarios(Ordenamiento, Rol, Estado).ToList();
            return usuarios;
        }

        // GET: api/Usuarios/5

        [HttpGet]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5

        [HttpPut]
        public Usuario PutModificarUsuario(int Id_Usuario, string Nombre_Usuario = null, string Apellido_Usuario = null, string Email = null, string Imagen = null, string Estado = null, string UserName = null, string Password = null, string Rol = null)
        {
            // Llama al stored procedure ppModificarUsuario con los parámetros opcionales
            db.ppModificarUsuario(Id_Usuario, Nombre_Usuario, Apellido_Usuario, Email, Imagen, Estado, UserName, Password, Rol);

            // Recupera y devuelve el registro actualizado (puedes hacerlo si lo deseas)
            Usuario usuarioMod = db.Usuario.Find(Id_Usuario);
            return usuarioMod;
        }






        [HttpPost]
        public IHttpActionResult PostUsuario([FromBody]  CreateUserDTO user)
        {
            string passwordHashed = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password,13); // Se hashea la password

            try
            {
                
                db.ppInsertarUsuario(user.Rol, user.Nombre, user.Apellido, user.Imagen, user.UserName, passwordHashed, user.Email, user.Estado);

                return Ok("Usuario insertado correctamente"); // Devuelve un HTTP 200 OK si se ingreso


            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " Los errores de validación son: ", fullErrorMessage);

                return BadRequest(exceptionMessage); // Devuelve una respuesta HTTP 400 Bad Request con los errores de valida

                
            }

        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.Id_Usuario == id) > 0;
        }
    }
}