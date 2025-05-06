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
        Task<List<paciente>> GetPacientes();
        Task<List<paciente>> GetPacientesByEdad(int edad);
        Task<paciente> GetPacienteById(int id);
        Task<paciente> InsertarPacienteNuevo(paciente nuevoPaciente);
        Task<string> ActualizarPaciente(int id, paciente pacienteActualizado);
        Task<string> EliminarPacientePorDni(int dni);
        Task<List<obra_social>> ObtenerObrasSociales();
        Task<List<tipo_enfermedad>> ObtenerTiposEnfermedad();
        Task<List<parentezco>> ObtenerParentezco();
        Task<List<metodo_anticonceptivo>> ObtenerMetodosAnticonceptivos();
    }
}
