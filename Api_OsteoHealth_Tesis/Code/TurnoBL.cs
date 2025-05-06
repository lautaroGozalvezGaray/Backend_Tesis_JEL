using Api_OsteoHealth_Tesis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Api_OsteoHealth_Tesis.ModelsCustom;

namespace Api_OsteoHealth_Tesis.Code
{
    /// <summary>
    /// Clase TurnoBL
    /// </summary>
    public class TurnoBL
    {
        private readonly OsteoHealthContext _context;

        /// <summary>
        /// Constructor de la clase TurnoBL
        /// </summary>
        /// <param name="context"></param>
        public TurnoBL(OsteoHealthContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Listar turnos por paciente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public async Task<List<TurnoDto>> ListarTurnosPorUsuario(Guid idUsuario)
        {
            return await _context.turnos
                .Where(t => t.idusuario == idUsuario)
                .OrderBy(t => t.fecha).ThenBy(t => t.hora)
                .Select(t => new TurnoDto
                {
                    fecha = t.fecha,
                    hora = t.hora,
                    duracionminutos = t.duracionminutos,
                    estadoturno = t.estadoturno,
                    observaciones = t.observaciones,
                    idusuario = t.idusuario,
                    idpaciente = t.idpaciente,
                    nombrepaciente = t.nombrepaciente,
                    apellidopaciente = t.apellidopaciente,
                    dnipaciente = t.dnipaciente
                })
                .ToListAsync();
        }


        /// <summary>
        /// Listar turnos por paciente
        /// </summary>
        /// <param name="nuevoTurno"></param>
        /// <returns></returns>
        public async Task<int> AgregarTurno(TurnoDto nuevoTurno)
        {
            var turno = new turno
            {
                fecha = nuevoTurno.fecha,
                hora = nuevoTurno.hora,
                duracionminutos = nuevoTurno.duracionminutos,
                estadoturno = nuevoTurno.estadoturno,
                observaciones = nuevoTurno.observaciones,
                idusuario = nuevoTurno.idusuario,
                idpaciente = nuevoTurno.idpaciente ?? 0, // usar 0 si es externo
                nombrepaciente = nuevoTurno.nombrepaciente,
                apellidopaciente = nuevoTurno.apellidopaciente,
                dnipaciente = nuevoTurno.dnipaciente
            };

            _context.turnos.Add(turno);
            await _context.SaveChangesAsync();
            return turno.dturno;
        }


        /// <summary>
        /// Actualizar turno
        /// </summary>
        /// <param name="turnoActualizado"></param>
        /// <returns></returns>
        public async Task<bool> ActualizarTurno(TurnoDto turnoActualizado)
        {
            var turno = await _context.turnos.FindAsync(turnoActualizado.dturno);
            if (turno == null) return false;

            turno.fecha = turnoActualizado.fecha;
            turno.hora = turnoActualizado.hora;
            turno.duracionminutos = turnoActualizado.duracionminutos;
            turno.estadoturno = turnoActualizado.estadoturno;
            turno.observaciones = turnoActualizado.observaciones;
            turno.idpaciente = turnoActualizado.idpaciente ?? 0;
            turno.nombrepaciente = turnoActualizado.nombrepaciente;
            turno.apellidopaciente = turnoActualizado.apellidopaciente;
            turno.dnipaciente = turnoActualizado.dnipaciente;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Eliminar turno
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns></returns>
        public async Task<bool> EliminarTurno(int idTurno)
        {
            var turno = await _context.turnos.FindAsync(idTurno);
            if (turno == null) return false;

            _context.turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
