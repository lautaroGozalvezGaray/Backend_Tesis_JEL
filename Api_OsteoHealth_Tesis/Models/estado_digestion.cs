using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("estado_digestion")]
public partial class estado_digestion
{
    [Key]
    public int idestadodigestion { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idestadodigestionNavigation")]
    public virtual ICollection<digestion> digestions { get; set; } = new List<digestion>();

    [InverseProperty("idestadodigestionNavigation")]
    public virtual ICollection<sesion> sesions { get; set; } = new List<sesion>();
}
