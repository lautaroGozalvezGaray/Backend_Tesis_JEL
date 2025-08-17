using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("obra_social")]
public partial class obra_social
{
    [Key]
    public int idobrasocial { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idobrasocialNavigation")]
    public virtual ICollection<paciente> pacientes { get; set; } = new List<paciente>();
}
