using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("digestion")]
public partial class digestion
{
    [Key]
    public int iddigestion { get; set; }

    public int idsesion { get; set; }

    public int? cantidadlapso { get; set; }

    public int idsintomadigestion { get; set; }

    public int idfrecuencialapso { get; set; }

    public int idestadodigestion { get; set; }

    [ForeignKey("idestadodigestion")]
    [InverseProperty("digestions")]
    public virtual estado_digestion idestadodigestionNavigation { get; set; }

    [ForeignKey("idfrecuencialapso")]
    [InverseProperty("digestions")]
    public virtual frecuencia_lapso idfrecuencialapsoNavigation { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("digestions")]
    public virtual sesion idsesionNavigation { get; set; }

    [ForeignKey("idsintomadigestion")]
    [InverseProperty("digestions")]
    public virtual sintoma_digestion idsintomadigestionNavigation { get; set; }
}
