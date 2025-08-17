using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sexo")]
public partial class sexo
{
    [Key]
    public int idsexo { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("sexoNavigation")]
    public virtual ICollection<paciente> pacientes { get; set; } = new List<paciente>();
}
