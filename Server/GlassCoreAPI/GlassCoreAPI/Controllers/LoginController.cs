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
        public IHttpActionResult PostLogin(long UserName, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarioLogin = db.Usuario.SingleOrDefault(u => u.UserName == UserName && u.Password == Password && u.Estado == "Activo");
            if (usuarioLogin != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(usuarioLogin.UserName, usuarioLogin.Id_Usuario, usuarioLogin.Rol);
                return Ok(token);
            }


            return Unauthorized();
        }

    }
}
