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
using GlassCoreAPI.Models;

namespace GlassCoreAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        private GlassCoreEntities db = new GlassCoreEntities();

        // GET: api/Usuarios
        public List<ppFiltrarUsuarios_Result> GetUsuarios(string Ordenamiento = "ASC", string Rol = null, string Estado = null)
        {
            var usuarios = db.ppFiltrarUsuarios(Ordenamiento, Rol, Estado).ToList();
            return usuarios;
        }

        // GET: api/Usuarios/5

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

        public Usuario PutModificarUsuario(int Id_Usuario, string Nombre_Usuario = null, string Apellido_Usuario = null, string Email = null, string Imagen = null, string Estado = null, long? UserName = null, string Password = null, string Rol = null)
        {
            // Llama al stored procedure ppModificarUsuario con los parámetros opcionales
            db.ppModificarUsuario(Id_Usuario, Nombre_Usuario, Apellido_Usuario, Email, Imagen, Estado, UserName, Password, Rol);

            // Recupera y devuelve el registro actualizado (puedes hacerlo si lo deseas)
            Usuario usuarioMod = db.Usuario.Find(Id_Usuario);
            return usuarioMod;
        }


        

        public IHttpActionResult PostUsuario(string Rol, long UserName, string Password, string Email, string Estado, string Nombre_Usuario, string Apellido_Usuario, string Imagen, string Carrera = null, string Titulo = null)
        {
            

            try
            {
                db.ppInsertarUsuario(Rol, Nombre_Usuario, Apellido_Usuario, Imagen, UserName, Password, Email, Estado);

                return Ok("Usuario insertado correctamente");


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

        [HttpPost]
        [Route("api/Usuarios/Login")]
        public int PostLogin(long UserName, string Password)
        {
            // Declarar un parámetro de salida para recibir el resultado del stored procedure
            SqlParameter resultadoParam = new SqlParameter("@TipoUsuario", SqlDbType.Int);
            resultadoParam.Direction = ParameterDirection.Output;

            // Llamar al stored procedure ppLogin y pasar el parámetro de salida
            db.Database.ExecuteSqlCommand("EXEC ppLogin @UserName, @Password, @TipoUsuario OUTPUT",
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password),
                resultadoParam);

            // Obtener el valor de retorno del parámetro de salida
            int resultado = (int)resultadoParam.Value;

            return resultado;
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