using Api_OsteoHealth_Tesis.Models;
using Api_OsteoHealth_Tesis.ModelsCustom;
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
        Task<List<ObraSocialDto>> ObtenerObrasSociales();
        Task<List<TipoEnfermedadDto>> ObtenerTiposEnfermedad();
        Task<List<ParentezcoDto>> ObtenerParentezco();
        Task<List<MetodoAnticonceptivoDto>> ObtenerMetodosAnticonceptivos();
        Task AgregarTipoEnfermedad(TipoEnfermedadDto dto);
        Task AgregarParentezco(ParentezcoDto dto);
        Task AgregarMetodoAnticonceptivo(MetodoAnticonceptivoDto dto);
        Task AgregarObraSocial(ObraSocialDto dto);
    }
}
