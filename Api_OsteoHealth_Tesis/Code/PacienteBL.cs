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
        private readonly OsteoHealthContext _context;

        /// <summary>
        /// Este es un constructor de la clase LoginController que utiliza inyección de dependencias 
        /// para recibir una instancia de DbOsteoHealthContext, 
        /// que es el contexto de Entity Framework Core configurado para tu base de datos.
        /// </summary>
        /// <param name="context"></param>
        public PacienteBL(OsteoHealthContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para obtener todos los pacientes ejemplo
        /// </summary>
        /// <returns></returns>
        public async Task<List<paciente>> GetPacientes()
        {
            try
            {
                return await _context.pacientes.ToListAsync();
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
        public async Task<List<paciente>> GetPacientesByEdad(int edad)
        {
            try
            {
                return await _context.pacientes.Where(p => p.edad == edad).ToListAsync();
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
        public async Task<paciente> GetPacienteById(int id)
        {
            try
            {
                return await _context.pacientes.FindAsync(id);
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
        public async Task<paciente> InsertarPacienteNuevo(paciente nuevoPaciente)
        {
            try
            {
                _context.pacientes.Add(nuevoPaciente);
                await _context.SaveChangesAsync();

                return await _context.pacientes.FindAsync(nuevoPaciente.dni);
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
        public async Task<string> ActualizarPaciente(int id, paciente pacienteActualizado)
        {
            try
            {
                var paciente = await _context.pacientes.FindAsync(id);
                if (paciente == null)
                    return "Paciente no encontrado";

                paciente.dni = pacienteActualizado.dni;
                paciente.nombre = pacienteActualizado.nombre;
                paciente.apellido = pacienteActualizado.apellido;
                paciente.fechanacimiento = pacienteActualizado.fechanacimiento;
                paciente.fechaingreso = pacienteActualizado.fechaingreso;
                paciente.edad = pacienteActualizado.edad;
                paciente.estado = pacienteActualizado.estado;
                paciente.peso = pacienteActualizado.peso;
                paciente.altura = pacienteActualizado.altura;
                paciente.sexo = pacienteActualizado.sexo;
                paciente.telefono = pacienteActualizado.telefono;
                paciente.email = pacienteActualizado.email;
                paciente.idantecedetoco = pacienteActualizado.idobrasocial;
                paciente.idimagen = pacienteActualizado.idimagen;
                paciente.idubicacion = pacienteActualizado.idubicacion;
                paciente.idinformacionadicional = pacienteActualizado.idinformacionadicional;
                paciente.idenfermedadhereditaria = pacienteActualizado.idenfermedadhereditaria;
                paciente.idantecedetoco = pacienteActualizado.idantecedetoco;

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
                var paciente = await _context.pacientes.FindAsync(dni);
                if (paciente == null)
                    return "Paciente no encontrado";

                _context.pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                return "Paciente eliminado";
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// Metodo para eliminar un paciente por su dni
        /// </summary>
        /// <returns></returns>
        public async Task<List<obra_social>> ObtenerObrasSociales()
        {
            try
            {
                var obraSociales = await _context.obra_socials.ToListAsync();

                return obraSociales.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// Metodo para obtener el lsitado de enfermedades
        /// </summary>
        /// <returns></returns>
        public async Task<List<tipo_enfermedad>> ObtenerTiposEnfermedad()
        {
            try
            {
                var tipoEnfermedads = await _context.tipo_enfermedads.ToListAsync();

                return tipoEnfermedads.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// Metodo para obtener los parentezcos
        /// </summary>
        /// <returns></returns>
        public async Task<List<parentezco>> ObtenerParentezco()
        {
            try
            {
                var parentezcos = await _context.parentezcos.ToListAsync();

                return parentezcos.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// Metodo para obtener los metodos anticonceptivos
        /// </summary>
        /// <returns></returns>
        public async Task<List<metodo_anticonceptivo>> ObtenerMetodosAnticonceptivos()
        {
            try
            {
                var tipoEnfermedads = await _context.metodo_anticonceptivos.ToListAsync();

                return tipoEnfermedads.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
