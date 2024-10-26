using Api_OsteoHealth_Tesis.Code;
using Microsoft.AspNetCore.Mvc;

namespace Api_OsteoHealth_Tesis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet(Name = "Login/AccesoUsuario")]
        public bool LogearUsuario(string username, string password)
        {
            return Login.ValidateLogin(username, password);
        }
    }
}
