using Api_OsteoHealth_Tesis.code;
using Api_OsteoHealth_Tesis.Models;
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
    /// Clase con l  
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class PacienteController:ControllerBase
    {
        private readonly IPacienteBL _pacienteBL;
        /// <summary>
        /// El constructor del controlador recibe una instancia de PacienteBL a través de la inyección de dependencias. 
        /// Esto permite que el controlador utilice los métodos de PacienteBL para realizar operaciones como obtener,
        /// insertar, actualizar y eliminar pacientes.
        /// </summary>
        public PacienteController(IPacienteBL pacienteBL)
        {
            _pacienteBL = pacienteBL;
        }

        /// <summary>
        /// Endpoint para obtener todos los pacientes
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> GetPacientes()
        {
            try
            {
                var pacientes = await _pacienteBL.GetPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Endpoint para obtener pacientes por edad
        /// </summary>
        /// <param name="edad">Edad de los pacientes</param>
        /// <returns>Lista de pacientes con la edad especificada</returns>
        [HttpGet("edad/{edad}")]
        public async Task<ActionResult<List<Paciente>>> GetPacientesByEdad(int edad)
        {
            try
            {
                var pacientes = await _pacienteBL.GetPacientesByEdad(edad);
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");

            }
        }

        /// <summary>
        /// Endpoint para obtener un paciente por su ID
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>El paciente encontrado o NotFound</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteById(int id)
        {
            try
            {
                var paciente = await _pacienteBL.GetPacienteById(id);
                if (paciente == null)
                    return NotFound("Paciente no encontrado");

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Endpoint para insertar un nuevo paciente
        /// </summary>
        /// <param name="nuevoPaciente">Datos del nuevo paciente</param>
        /// <returns>El paciente insertado</returns>
        [HttpPost]
        public async Task<ActionResult<Paciente>> InsertarPacienteNuevo(Paciente nuevoPaciente)
        {
            try
            {
                if (nuevoPaciente == null)
                    return BadRequest("Los datos del paciente son inválidos.");

                var pacienteInsertado = await _pacienteBL.InsertarPacienteNuevo(nuevoPaciente);
                return CreatedAtAction(nameof(GetPacienteById), new { id = pacienteInsertado.Dni }, pacienteInsertado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");

            }
        }


        /// <summary>
        /// Endpoint para actualizar un paciente
        /// </summary>
        /// <param name="id">ID del paciente a actualizar</param>
        /// <param name="pacienteActualizado">Datos actualizados del paciente</param>
        /// <returns>Mensaje de estado de la actualización</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> ActualizarPaciente(int id, Paciente pacienteActualizado)
        {
            try
            {
                var resultado = await _pacienteBL.ActualizarPaciente(id, pacienteActualizado);
                if (resultado == "Paciente no encontrado")
                    return NotFound(resultado);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Endpoint para eliminar un paciente por su DNI
        /// </summary>
        /// <param name="dni">DNI del paciente a eliminar</param>
        /// <returns>Mensaje de estado de la eliminación</returns>
        [HttpDelete("{dni}")]
        public async Task<ActionResult<string>> EliminarPacientePorDni(int dni)
        {
            try
            {
                var resultado = await _pacienteBL.EliminarPacientePorDni(dni);
                if (resultado == "Paciente no encontrado")
                    return NotFound(resultado);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

    }
}
