using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("actividad_laboral_profesional")]
public partial class actividad_laboral_profesional
{
    [Key]
    public int idactividadlaboralprofesional { get; set; }

    public int idsesion { get; set; }

    public int? cantidadlapso { get; set; }

    [StringLength(50)]
    public string tiempovigencia { get; set; }

    public int idfrecuencialapso { get; set; }

    public int idestiloactividadlaboral { get; set; }

    public int idtipoactividadlaboral { get; set; }

    [ForeignKey("idestiloactividadlaboral")]
    [InverseProperty("actividad_laboral_profesionals")]
    public virtual estilo_actividad_laboral idestiloactividadlaboralNavigation { get; set; }

    [ForeignKey("idfrecuencialapso")]
    [InverseProperty("actividad_laboral_profesionals")]
    public virtual frecuencia_lapso idfrecuencialapsoNavigation { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("actividad_laboral_profesionals")]
    public virtual sesion idsesionNavigation { get; set; }

    [ForeignKey("idtipoactividadlaboral")]
    [InverseProperty("actividad_laboral_profesionals")]
    public virtual tipo_actividad_laboral idtipoactividadlaboralNavigation { get; set; }
}
