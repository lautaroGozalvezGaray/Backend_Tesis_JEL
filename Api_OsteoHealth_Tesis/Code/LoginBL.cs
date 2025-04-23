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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        /// <param name="configuration"></param>
        public LoginBL(DbOsteoHealthContext context, IConfiguration configuration)
        {
            _context      = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<string> GenerateJwtToken(string userId, string role)
        {
            try
            {
                // Validar configuración JWT
                var keyString = _configuration["Jwt:Key"];
                if (string.IsNullOrEmpty(keyString))
                {
                    return null;
                }

                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
                {
                    return null;
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Definir los claims del usuario
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
                };

                // Crear el token JWT
                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                return null; // Retornar null en caso de error
                throw new Exception("Error al generar el token JWT", ex);
            }
        }

        /// <summary>
        /// Valida las credenciales del usuario en la base de datos.
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns>Tupla con validación, ID de usuario y rol</returns>
        public async Task<(bool isValid, string userId, string role)> ValidateUserAsync(string username, string password)
        {
            try
            {
                var user = await _context.Set<Usuario>()
                    .FirstOrDefaultAsync(u => u.username == username && u.password == password);

                if (user != null)
                {
                    return (true, user.IdUsuario.ToString(), user.Rol);
                }

                return (false, "", null);
            }
            catch (Exception ex)
            {
                return (false, "", null);
                throw new Exception("Error al validar el usuario", ex);
            }
        }

    }

}
