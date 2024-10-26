using System;

namespace Api_OsteoHealth_Tesis.Models
{
    /// <summary>
    /// Clase que representa a un paciente
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// Documento del paciente
        /// </summary>
        public int Dni { get; set; }

        /// <summary>
        /// Nombre del paciente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del paciente
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Fecha de ingreso del paciente
        /// </summary>
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Fecha de nacimiento del paciente
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// Edad del paciente
        /// </summary>
        public int? Edad { get; set; }

        /// <summary>
        /// Estado del paciente
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Peso del paciente
        /// </summary>
        public decimal? Peso { get; set; }

        /// <summary>
        /// Altura del paciente
        /// </summary>
        public decimal? Altura { get; set; }

        /// <summary>
        /// Sexo del paciente
        /// </summary>
        public int? Sexo { get; set; }

        /// <summary>
        /// Teléfono del paciente
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Email del paciente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ID de la obra social del paciente
        /// </summary>
        public int IdObraSocial { get; set; }

        /// <summary>
        /// ID de la imagen del paciente
        /// </summary>
        public int IdImagen { get; set; }

        /// <summary>
        /// ID de la ubicación del paciente
        /// </summary>
        public int IdUbicacion { get; set; }

        /// <summary>
        /// ID de la información adicional del paciente
        /// </summary>
        public int IdInformacionAdicional { get; set; }

        /// <summary>
        /// ID de la enfermedad hereditaria del paciente
        /// </summary>
        public int IdEnfermedadHereditaria { get; set; }

        /// <summary>
        /// ID de antecedentes tocoginecológicos del paciente
        /// </summary>
        public int IdAntecedeToco { get; set; }
    }
}
