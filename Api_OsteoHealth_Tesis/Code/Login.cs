using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api_OsteoHealth_Tesis.Code
{
    public class Login
    {

        public static bool ValidateLogin(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }

    }
}
