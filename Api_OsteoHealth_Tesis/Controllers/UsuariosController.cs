using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.Repository;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Controllers
{
   /* [ApiVersion("1.0")]
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]*/

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioBL _usuarioBL;

        public UsuariosController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await _usuarioBL.ObtenerUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = await _usuarioBL.ObtenerUsuarioPorIdAsync(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado.");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                if (nuevoUsuario == null)
                    return BadRequest("Los datos del usuario no pueden ser nulos.");

                var resultado = await _usuarioBL.CrearUsuarioAsync(nuevoUsuario);
                if (!resultado)
                    return StatusCode(500, "No se pudo crear el usuario.");

                return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarUsuario(Guid id, [FromBody] Usuario usuarioActualizado)
        {
            try
            {
                if (usuarioActualizado == null /* || id != usuarioActualizado.IdUsuario*/)
                    return BadRequest("Datos inválidos para la actualización.");

                var resultado = await _usuarioBL.ActualizarUsuarioAsync(id, usuarioActualizado);
                if (!resultado)
                    return NotFound("Usuario no encontrado o no se pudo actualizar.");

                return Ok("Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina un usuario por su ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarUsuario(Guid id)
        {
            try
            {
                var resultado = await _usuarioBL.EliminarUsuarioAsync(id);
                if (!resultado)
                    return NotFound("Usuario no encontrado o no se pudo eliminar.");

                return Ok("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el usuario: {ex.Message}");
            }
        }





    }
}
