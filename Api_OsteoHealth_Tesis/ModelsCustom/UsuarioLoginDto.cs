namespace Api_OsteoHealth_Tesis.ModelsCustom
{
    /// <summary>
    /// Clase para representar un usuario en el sistema.
    /// </summary>
    public class UsuarioLoginDto
    {
        /// <summary>
        /// Nombre de usuario del usuario.
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string password { get; set; }
    }
}
