using Api_OsteoHealth_Tesis.Code;
using Api_OsteoHealth_Tesis.Repository;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api_OsteoHealth_Tesis.Controllers
{
    /// <summary>
    /// Endpoint para el login   
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginBL _loginBL;
        /// <summary>
        /// El constructor del controlador recibe una instancia de PacienteBL a través de la inyección de dependencias. 
        /// Esto permite que el controlador utilice los métodos de PacienteBL para realizar operaciones como obtener,
        /// insertar, actualizar y eliminar pacientes.
        /// </summary>
        public LoginController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        /// <summary>
        /// Metodo para validar el login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        private readonly LoginBL _loginBL;

        public LoginController(LoginBL loginBL)
        {
            _loginBL = loginBL;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            if (_loginBL.ValidateUser(username, password, out int userId, out string role))
            {
                var token = _loginBL.GenerateJwtToken(userId, role);
                return Ok(new { token });
            }
            return Unauthorized();
        }




        /*[HttpGet]
        public IActionResult ValidateLogin(string username, string password, int id)
        {
            //borrar, solo es para que aparezca el endpoint
            if (LoginBL.ValidateLogin(username, password, id))
            {
                return Ok();
            }
            return Unauthorized();
        }*/
    }
}
