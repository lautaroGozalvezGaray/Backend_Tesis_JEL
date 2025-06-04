using Api_OsteoHealth_Tesis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Api_OsteoHealth_Tesis.ModelsCustom;

namespace Api_OsteoHealth_Tesis.Repository
{
    /// <summary>
    /// Interface TurnoBL
    /// </summary>
    public interface ITurnoBL
    {
        /// <summary>
        /// Listar turnos por paciente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task<List<turno>> ListarTurnosPorUsuario(Guid idUsuario);
        /// <summary>
        /// Agregar un nuevo turno
        /// </summary>
        /// <param name="nuevoTurno"></param>
        /// <returns></returns>
        Task<int> AgregarTurno(TurnoDto nuevoTurno);
        /// <summary>
        /// Actualizar turno
        /// </summary>
        /// <param name="turnoActualizado"></param>
        /// <returns></returns>
        Task<bool> ActualizarTurno(TurnoDto turnoActualizado);
        /// <summary>
        /// Eliminar turno
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns></returns>
        Task<bool> EliminarTurno(int idTurno);

    }
}
