using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("imagen_paciente")]
public partial class imagen_paciente
{
    [Key]
    public int idimagen { get; set; }

    public byte[] imagen { get; set; }

    [InverseProperty("idimagenNavigation")]
    public virtual ICollection<paciente> pacientes { get; set; } = new List<paciente>();
}
