using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.ModelsCustom;
using Api_OsteoHealth_Tesis.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace Api_OsteoHealth_Tesis.Code
{
    public class UsuarioBL : IUsuarioBL
    {

        private readonly OsteoHealthContext _context;

        public UsuarioBL(OsteoHealthContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<bool> CrearUsuarioAsync(Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return (true);
            }
            catch (Exception ex)
            {
                return (false);
            }
        }

        public async Task<bool> ActualizarUsuarioAsync(Guid id, Usuario usuarioActualizado)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario == null) return (false);

            usuario.username = usuarioActualizado.username;
            usuario.password = usuarioActualizado.password;
            usuario.Rol = usuarioActualizado.Rol;
            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Apellido = usuarioActualizado.Apellido;
            usuario.FotoPerfil = usuarioActualizado.FotoPerfil;

            await _context.SaveChangesAsync();
            return (true);
        }

        public async Task<bool> EliminarUsuarioAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario == null) return (false);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return (true);
        }
    }
}
