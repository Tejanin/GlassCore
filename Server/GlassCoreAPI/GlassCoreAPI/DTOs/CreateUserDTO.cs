using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassCoreAPI.DTOs
{
    public class CreateUserDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Rol { get; set; }

        public string Estado { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmed { get; set; }


        public string  Imagen { get; set; }
    }
}