using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipo_actividad_laboral")]
public partial class tipo_actividad_laboral
{
    [Key]
    public int idtipoactividadlaboral { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idtipoactividadlaboralNavigation")]
    public virtual ICollection<actividad_laboral_profesional> actividad_laboral_profesionals { get; set; } = new List<actividad_laboral_profesional>();
}
