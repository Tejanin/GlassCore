using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;


namespace GlassCoreAPI.Controllers
{
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(long username, int id , string rol)
        {
            // appsetting for Token JWT
          
            var audienceToken = "audienceToken";
            var issuerToken = "issuerToken";


            var securityKey = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(securityKey);
            }

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            // create a claimsIdentity
            var claims = new List<Claim>
              {
                   new Claim("Matricula", username.ToString()),
                   new Claim("UserId", id.ToString()), // Agregar el ID como Claim personalizado
                   new Claim(ClaimTypes.Role, rol),
                  
              };

            // Crear un objeto ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(claims);

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}