using GlassCoreAPI.DTOs;
using GlassCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GlassCoreAPI.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    
    public class LoginController : ApiController
    {
        private GlassCoreEntities db = new GlassCoreEntities();

        [HttpPost]
        public IHttpActionResult PostLogin(LoginUserDTO user)
        {
            // Hashear la contraseña proporcionada por el usuario
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar al usuario por nombre de usuario y estado activo
            var usuarioLogin = db.Usuario.SingleOrDefault(u => u.UserName == user.User && u.Estado == "Activo");

            // Verificar si el usuario existe y la contraseña coincide
            if (usuarioLogin != null && BCrypt.Net.BCrypt.EnhancedVerify(user.Password, usuarioLogin.Password))
            {
                var est = db.Estudiante.SingleOrDefault(e => e.Id_Usuario == usuarioLogin.Id_Usuario);
                int id = est.Id_Estudiante;
                // Generar un token JWT si la autenticación es exitosa
                var token = TokenGenerator.GenerateTokenJwt(usuarioLogin.UserName, usuarioLogin.Id_Usuario, usuarioLogin.Rol, id);
                return Ok(token);
            }

            // Retornar Unauthorized si la autenticación falla
            return Unauthorized();
        }

    }
}
