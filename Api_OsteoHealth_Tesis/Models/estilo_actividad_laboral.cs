using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("estilo_actividad_laboral")]
public partial class estilo_actividad_laboral
{
    [Key]
    public int idestiloactividadlaboral { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idestiloactividadlaboralNavigation")]
    public virtual ICollection<actividad_laboral_profesional> actividad_laboral_profesionals { get; set; } = new List<actividad_laboral_profesional>();
}
