using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        // PUT api/Usuarios
        [HttpPut]
        [Route("api/Usuarios/{Id_Usuario}")]
        public Usuario PutModificarUsuario(int Id_Usuario, string Nombre_Usuario, string Apellido_Usuario, string Email, string Imagen, string Estado, string UserName, string Password, string Rol)
        {
            db.ppModificarUsuario(Id_Usuario,  Nombre_Usuario,  Apellido_Usuario,  Email, Imagen,  Estado,  UserName,  Password,  Rol);
            Usuario usuarioMod = db.Usuario.Find(Id_Usuario);
            return usuarioMod;
        }

        // PUT  api/Usuarios/ModificarEstado

        [HttpPut]
        [Route("api/Usuarios/{Id_Usuario}/ModificarEstado")]
        public Usuario PutModificarEstadoUsuario(int Id_Usuario, string Estado)
        {
            db.ppModificarEstadoUsuario(Id_Usuario, Estado);
            Usuario usuarioMod = db.Usuario.Find(Id_Usuario);
            return usuarioMod;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id_Usuario)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        
        public async Task<IHttpActionResult> PostUsuario(string Rol, string UserName, string Password, string Email, string Estado, string Nombre_Usuario, string Apellido_Usuario, string Imagen)
        {
            try
            {
                db.ppInsertarUsuario(Rol, UserName, Password, Email, Estado, Nombre_Usuario, Apellido_Usuario, Imagen);
                return Ok("Usuario insertado correctamente");

            }
            catch (Exception ex)
            {
                return Ok("Hubo un error :" + ex.Message);
            }
            
        }

        // DELETE: api/Usuarios/5
       
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