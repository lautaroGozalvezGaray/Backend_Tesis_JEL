using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("frecuencia_lapso")]
public partial class frecuencia_lapso
{
    [Key]
    public int idfrecuencialapso { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idfrecuencialapsoNavigation")]
    public virtual ICollection<actividad_fisica> actividad_fisicas { get; set; } = new List<actividad_fisica>();

    [InverseProperty("idfrecuencialapsoNavigation")]
    public virtual ICollection<actividad_laboral_profesional> actividad_laboral_profesionals { get; set; } = new List<actividad_laboral_profesional>();

    [InverseProperty("idfrecuencialapsoNavigation")]
    public virtual ICollection<digestion> digestions { get; set; } = new List<digestion>();

    [InverseProperty("idfrecuencialapsoNavigation")]
    public virtual ICollection<habitos_toxico> habitos_toxicos { get; set; } = new List<habitos_toxico>();
}
