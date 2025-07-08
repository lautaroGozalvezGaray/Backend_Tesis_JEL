using Api_OsteoHealth_Tesis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Api_OsteoHealth_Tesis.Repository
{
    public interface IUsuarioBL
    {
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(Guid id);
        Task<bool> CrearUsuarioAsync(Usuario nuevoUsuario);
        Task<bool> ActualizarUsuarioAsync(Guid id, Usuario usuarioActualizado);
        Task<bool> EliminarUsuarioAsync(Guid id);

    }
}
