using Api_OsteoHealth_Tesis.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System;
using Api_OsteoHealth_Tesis.Repository;

namespace Api_OsteoHealth_Tesis.Code
{
    /// <summary>
    /// Clase con metodos para login
    /// </summary>
    public class LoginBL:ILoginBL
    {
        private readonly DbOsteoHealthContext _context;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Este es un constructor de la clase LoginController que utiliza inyección de dependencias 
        /// para recibir una instancia de DbOsteoHealthContext, 
        /// que es el contexto de Entity Framework Core configurado para tu base de datos.
        /// </summary>
        /// <param name="context"></param>
        public LoginBL(DbOsteoHealthContext context, IConfiguration configuration)
        {
            _context      = context;
            _configuration = configuration;
        }
        /// <summary>
        /// Valida el login de un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /*public static bool ValidateLogin(string username, string password, int id)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }*/


        public string GenerateJwtToken(int userId, string role)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateUser(string username, string password, out int userId, out string role)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Nombre == username && u.Contrasena == password);

            if (user != null)
            {
                userId = user.IdUsuario;
                role = user.Rol;
                return true;
            }

            userId = 0;
            role = null;
            return false;
        }
    }

}
