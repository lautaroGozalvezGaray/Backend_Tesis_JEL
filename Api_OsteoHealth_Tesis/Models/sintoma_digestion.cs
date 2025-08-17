using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sintoma_digestion")]
public partial class sintoma_digestion
{
    [Key]
    public int idsintomadigestion { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idsintomadigestionNavigation")]
    public virtual ICollection<digestion> digestions { get; set; } = new List<digestion>();
}
