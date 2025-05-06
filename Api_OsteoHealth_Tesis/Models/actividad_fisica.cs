using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("actividad_fisica")]
public partial class actividad_fisica
{
    [Key]
    public int idactividadfisica { get; set; }

    public int idsesion { get; set; }

    [Precision(5, 2)]
    public decimal? tiempodedicadoxsession { get; set; }

    [StringLength(50)]
    public string tiempovigencia { get; set; }

    public int? cantidadlapso { get; set; }

    public int? idfrecuencialapso { get; set; }

    public int? idtipoactividadfisica { get; set; }

    [ForeignKey("idfrecuencialapso")]
    [InverseProperty("actividad_fisicas")]
    public virtual frecuencia_lapso idfrecuencialapsoNavigation { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("actividad_fisicas")]
    public virtual sesion idsesionNavigation { get; set; }

    [ForeignKey("idtipoactividadfisica")]
    [InverseProperty("actividad_fisicas")]
    public virtual tipo_actividad_fisica idtipoactividadfisicaNavigation { get; set; }
}
