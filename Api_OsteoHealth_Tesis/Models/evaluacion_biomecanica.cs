using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("evaluacion_biomecanica")]
public partial class evaluacion_biomecanica
{
    [Key]
    public int idevaluacionbiomecanica { get; set; }

    public int idsesion { get; set; }

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<desplante_linea> desplante_lineas { get; set; } = new List<desplante_linea>();

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<estabilidad_rotacion> estabilidad_rotacions { get; set; } = new List<estabilidad_rotacion>();

    [ForeignKey("idsesion")]
    [InverseProperty("evaluacion_biomecanicas")]
    public virtual sesion idsesionNavigation { get; set; }

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<levantamiento_pierna> levantamiento_piernas { get; set; } = new List<levantamiento_pierna>();

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<movilidad_hombro> movilidad_hombros { get; set; } = new List<movilidad_hombro>();

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<paso_obstaculo> paso_obstaculos { get; set; } = new List<paso_obstaculo>();

    [InverseProperty("idevaluacionbiomecanicaNavigation")]
    public virtual ICollection<sentadilla> sentadillas { get; set; } = new List<sentadilla>();
}
