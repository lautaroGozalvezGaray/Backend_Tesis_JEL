using Api_OsteoHealth_Tesis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_OsteoHealth_Tesis.Code
{
    /// <summary>
    /// Clase con la logica de negocio para paciente
    /// </summary>
    public class PacienteBL
    {
        private readonly DbOsteoHealthContext _context;

        /// <summary>
        /// Este es un constructor de la clase LoginController que utiliza inyección de dependencias 
        /// para recibir una instancia de DbOsteoHealthContext, 
        /// que es el contexto de Entity Framework Core configurado para tu base de datos.
        /// </summary>
        /// <param name="context"></param>
        public  PacienteBL(DbOsteoHealthContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para obtener todos los pacientes ejemplo
        /// </summary>
        /// <returns></returns>
        public async Task<List<Paciente>> GetPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return pacientes;
        }

        /// <summary>
        /// Metodo para obtener un paciente por su edad
        /// </summary>
        /// <param name="edad"></param>
        /// <returns></returns>
        public async Task<List<Paciente>> GetPacientesByEdad(int edad)
        {
            var pacientes = await _context.Pacientes
                                          .Where(p => p.Edad == edad)
                                          .ToListAsync();
            return pacientes;
        }

        /// <summary>
        /// Obtiene un paciente por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Paciente> GetPacienteById(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            return paciente;
        }

        /// <summary>
        /// inserta un nuevo paciente y devuelve el paciente insertado
        /// </summary>
        /// <param name="nuevoPaciente"></param>
        /// <returns></returns>
        public async Task<Paciente> InsertarPacienteNuevo(Paciente nuevoPaciente)
        {
            _context.Pacientes.Add(nuevoPaciente);
            await _context.SaveChangesAsync();

            var pacienteInsertado = await _context.Pacientes.FindAsync(nuevoPaciente.Dni);

            return pacienteInsertado;
        }

        /// <summary>
        /// Actualiza los datas de un paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacienteActualizado"></param>
        /// <returns></returns>
        public async Task<string> ActualizarPaciente(int id, Paciente pacienteActualizado)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
                return "Paciente no encontrado";

            // Actualizar campos
            paciente.Nombre = pacienteActualizado.Nombre;
            paciente.Edad = pacienteActualizado.Edad;
            // otros campos...

            await _context.SaveChangesAsync();

            return "Paciente Actualizado";
        }

        /// <summary>
        /// Metodo para eliminar un paciente por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<string> EliminarPacientePorDni(int dni)
        {
            var paciente = await _context.Pacientes.FindAsync(dni);

            if (paciente == null)
                return "Paciente no encontrado";

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return "Paciente eliminado";
        }
    }
}
