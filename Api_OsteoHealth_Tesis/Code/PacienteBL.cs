using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_OsteoHealth_Tesis.code
{
    /// <summary>
    /// Clase con la logica de negocio para paciente
    /// </summary>
    public class PacienteBL : IPacienteBL
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
            try
            {
                return await _context.Pacientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener un paciente por su edad
        /// </summary>
        /// <param name="edad"></param>
        /// <returns></returns>
        public async Task<List<Paciente>> GetPacientesByEdad(int edad)
        {
            try
            {
                return await _context.Pacientes.Where(p => p.Edad == edad).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un paciente por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Paciente> GetPacienteById(int id)
        {
            try
            {
                return await _context.Pacientes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// inserta un nuevo paciente y devuelve el paciente insertado
        /// </summary>
        /// <param name="nuevoPaciente"></param>
        /// <returns></returns>
        public async Task<Paciente> InsertarPacienteNuevo(Paciente nuevoPaciente)
        {
            try
            {
                _context.Pacientes.Add(nuevoPaciente);
                await _context.SaveChangesAsync();

                return await _context.Pacientes.FindAsync(nuevoPaciente.Dni);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Actualiza los datas de un paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacienteActualizado"></param>
        /// <returns></returns>
        public async Task<string> ActualizarPaciente(int id, Paciente pacienteActualizado)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(id);
                if (paciente == null)
                    return "Paciente no encontrado";

                paciente.Dni = pacienteActualizado.Dni;
                paciente.Nombre = pacienteActualizado.Nombre;
                paciente.Apellido = pacienteActualizado.Apellido;
                paciente.FechaNacimiento = pacienteActualizado.FechaNacimiento;
                paciente.FechaIngreso = pacienteActualizado.FechaIngreso;
                paciente.Edad = pacienteActualizado.Edad;
                paciente.Estado = pacienteActualizado.Estado;
                paciente.Peso = pacienteActualizado.Peso;
                paciente.Altura = pacienteActualizado.Altura;
                paciente.Sexo = pacienteActualizado.Sexo;
                paciente.Telefono = pacienteActualizado.Telefono;
                paciente.Email = pacienteActualizado.Email;
                paciente.IdAntecedeToco = pacienteActualizado.IdObraSocial;
                paciente.IdImagen = pacienteActualizado.IdImagen;
                paciente.IdUbicacion = pacienteActualizado.IdUbicacion;
                paciente.IdInformacionAdicional = pacienteActualizado.IdInformacionAdicional;
                paciente.IdEnfermedadHereditaria = pacienteActualizado.IdEnfermedadHereditaria;
                paciente.IdAntecedeToco = pacienteActualizado.IdAntecedeToco;

                await _context.SaveChangesAsync();
                return "Paciente Actualizado";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para eliminar un paciente por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<string> EliminarPacientePorDni(int dni)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(dni);
                if (paciente == null)
                    return "Paciente no encontrado";

                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                return "Paciente eliminado";
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
