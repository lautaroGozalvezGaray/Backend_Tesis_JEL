using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("informacion_adicional")]
public partial class informacion_adicional
{
    [Key]
    public int idinformacionadicional { get; set; }

    public int? dni { get; set; }

    [StringLength(100)]
    public string tiempoafeccion { get; set; }

    [StringLength(255)]
    public string motivo { get; set; }

    [StringLength(255)]
    public string referencia { get; set; }

    [InverseProperty("idinformacionadicionalNavigation")]
    public virtual ICollection<paciente> pacientes { get; set; } = new List<paciente>();
}
