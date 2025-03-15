namespace Api_OsteoHealth_Tesis.Models
{
    /// <summary>
    /// Modelo para la petición de login
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
    }
}
