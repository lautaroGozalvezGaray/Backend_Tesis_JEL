using Api_OsteoHealth_Tesis.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api_OsteoHealth_Tesis.Code
{
    /// <summary>
    /// Clase con metodos para login
    /// </summary>
    public class LoginBL
    {
        private readonly DbOsteoHealthContext _context;

        /// <summary>
        /// Este es un constructor de la clase LoginController que utiliza inyección de dependencias 
        /// para recibir una instancia de DbOsteoHealthContext, 
        /// que es el contexto de Entity Framework Core configurado para tu base de datos.
        /// </summary>
        /// <param name="context"></param>
        public LoginBL(DbOsteoHealthContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Valida el login de un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ValidateLogin(string username, string password, int id)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }

    }
}
