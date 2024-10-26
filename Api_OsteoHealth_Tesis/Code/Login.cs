using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api_OsteoHealth_Tesis.Code
{
    public class Login
    {

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
