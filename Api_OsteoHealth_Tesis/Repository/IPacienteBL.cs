using Api_OsteoHealth_Tesis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_OsteoHealth_Tesis.Repository
{
    /// <summary>
    /// Interface PacienteBL
    /// </summary>
    public interface IPacienteBL
    {
        Task<List<Paciente>> GetPacientes();
        Task<List<Paciente>> GetPacientesByEdad(int edad);
        Task<Paciente> GetPacienteById(int id);
        Task<Paciente> InsertarPacienteNuevo(Paciente nuevoPaciente);
        Task<string> ActualizarPaciente(int id, Paciente pacienteActualizado);
        Task<string> EliminarPacientePorDni(int dni);
    }
}
