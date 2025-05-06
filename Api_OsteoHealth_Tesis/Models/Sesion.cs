using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sesion")]
public partial class sesion
{
    [Key]
    public int idsesion { get; set; }

    public int? dni { get; set; }

    public DateOnly? fecha { get; set; }

    public int idcaracteristicas { get; set; }

    public int idestadodigestion { get; set; }

    public int idsueno { get; set; }

    public int idalimentacion { get; set; }

    public int idhabitotoxico { get; set; }

    public int idactividadlaboralprofesional { get; set; }

    public int idsintomaclinico { get; set; }

    public int idescuchaosteopatica { get; set; }

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<actividad_fisica> actividad_fisicas { get; set; } = new List<actividad_fisica>();

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<actividad_laboral_profesional> actividad_laboral_profesionals { get; set; } = new List<actividad_laboral_profesional>();

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<alimentacion> alimentacions { get; set; } = new List<alimentacion>();

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<digestion> digestions { get; set; } = new List<digestion>();

    [ForeignKey("dni")]
    [InverseProperty("sesions")]
    public virtual paciente dniNavigation { get; set; }

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<estudios_nosocologico> estudios_nosocologicos { get; set; } = new List<estudios_nosocologico>();

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<evaluacion_biomecanica> evaluacion_biomecanicas { get; set; } = new List<evaluacion_biomecanica>();

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<habitos_toxico> habitos_toxicos { get; set; } = new List<habitos_toxico>();

    [ForeignKey("idcaracteristicas")]
    [InverseProperty("sesions")]
    public virtual caracteristica idcaracteristicasNavigation { get; set; }

    [ForeignKey("idestadodigestion")]
    [InverseProperty("sesions")]
    public virtual estado_digestion idestadodigestionNavigation { get; set; }

    [ForeignKey("idsintomaclinico")]
    [InverseProperty("sesions")]
    public virtual sintoma_clinico idsintomaclinicoNavigation { get; set; }

    [ForeignKey("idsueno")]
    [InverseProperty("sesions")]
    public virtual sueno idsuenoNavigation { get; set; }

    [InverseProperty("idsesionNavigation")]
    public virtual ICollection<tratamiento_efectuado> tratamiento_efectuados { get; set; } = new List<tratamiento_efectuado>();
}
