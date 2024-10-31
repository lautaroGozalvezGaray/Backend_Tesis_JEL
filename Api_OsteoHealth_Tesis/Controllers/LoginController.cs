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
        [HttpGet]
        public IActionResult ValidateLogin(string username, string password, int id)
        {
            //borrar, solo es para que aparezca el endpoint
            if (LoginBL.ValidateLogin(username, password, id))
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}
