using Api_OsteoHealth_Tesis.Code;
using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.ModelsCustom;
using Api_OsteoHealth_Tesis.Repository;
using Asp.Versioning;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        /// Endopoint para autenticar un usuario
        /// </summary>
        /// <param name="loginRequest">parametros para logear</param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UsuarioLoginDto loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.username) || string.IsNullOrEmpty(loginRequest.password))
            {
                return BadRequest(new { message = "Username y Password son obligatorios." });
            }

            var (isValid, userId, role) = await _loginBL.ValidateUserAsync(loginRequest.username, loginRequest.password);

            if (isValid)
            {
                var token = await _loginBL.GenerateJwtToken(userId, role);
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Credenciales incorrectas." });
        }

    }
}
