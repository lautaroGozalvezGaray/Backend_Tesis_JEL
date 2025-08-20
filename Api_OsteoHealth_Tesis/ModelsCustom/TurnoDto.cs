using System;

namespace Api_OsteoHealth_Tesis.ModelsCustom
{
    /// <summary>
    /// Clase TurnoDto
    /// </summary>
    public class TurnoDto
    {
        /// <summary>
        /// Identificador del turno
        /// </summary>
        public int dturno { get; set; }

        /// <summary>
        /// Identificador del turno
        /// </summary>
        public DateOnly fecha { get; set; }

        /// <summary>
        /// Hora del turno
        /// </summary>
        public TimeOnly hora { get; set; }

        /// <summary>
        /// Duración del turno en minutos
        /// </summary>
        public int? duracionminutos { get; set; }

        /// <summary>
        /// Estado del turno
        /// </summary>
        public string estadoturno { get; set; }

        /// <summary>
        /// Observaciones del turno
        /// </summary>
        public string observaciones { get; set; }

        /// <summary>
        /// Identificador del usuario que creó el turno
        /// </summary>
        public Guid idusuario { get; set; }

        /// <summary>
        /// Identificador del paciente
        /// </summary>
        public int? idpaciente { get; set; } // nullable por si es paciente externo

        /// <summary>
        /// Nombre del paciente
        /// </summary>
        public string nombrepaciente { get; set; }

        /// <summary>
        /// Apellido del paciente
        /// </summary>
        public string apellidopaciente { get; set; }

        /// <summary>
        /// DNI del paciente
        /// </summary>
        public string dnipaciente { get; set; }
    }

}
