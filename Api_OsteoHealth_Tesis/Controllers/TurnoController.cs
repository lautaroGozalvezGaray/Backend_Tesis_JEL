using Api_OsteoHealth_Tesis.Code;
using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.ModelsCustom;
using Api_OsteoHealth_Tesis.Repository;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_OsteoHealth_Tesis.Controllers
{
    /// <summary>
    /// Endpoint para el login   
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class TurnoController:ControllerBase
    {
        private readonly ITurnoBL _turnoBL;

        /// <summary>
        /// El constructor del controlador recibe una instancia de PacienteBL a través de la inyección de dependencias.
        /// </summary>
        /// <param name="turnoBL"></param>
        public TurnoController(ITurnoBL turnoBL)
        {
            _turnoBL = turnoBL;
        }

        /// <summary>
        /// Listar los turnos del usuario logueado
        /// </summary>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<List<TurnoDto>>> ListarTurnos(Guid idUsuario)
        {
            try
            {
                var turnos = await _turnoBL.ListarTurnosPorUsuario(idUsuario);
                return Ok(turnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Agregar un nuevo turno
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AgregarTurno([FromBody] TurnoDto nuevoTurno)
        {
            try
            {
                var id = await _turnoBL.AgregarTurno(nuevoTurno);
                return Ok(new { idTurno = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualizar un turno existente
        /// </summary>
        [HttpPut("{idTurno}")]
        public async Task<ActionResult> ActualizarTurno(int idTurno, [FromBody] TurnoDto turnoActualizado)
        {
            if (idTurno != turnoActualizado.dturno)
                return BadRequest("ID de turno no coincide");

            try
            {
                var actualizado = await _turnoBL.ActualizarTurno(turnoActualizado);
                if (!actualizado) return NotFound("Turno no encontrado");

                return Ok("Turno actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Eliminar un turno por ID
        /// </summary>
        [HttpDelete("{idTurno}")]
        public async Task<ActionResult> EliminarTurno(int idTurno)
        {
            try
            {
                var eliminado = await _turnoBL.EliminarTurno(idTurno);
                if (!eliminado) return NotFound("Turno no encontrado");

                return Ok("Turno eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
