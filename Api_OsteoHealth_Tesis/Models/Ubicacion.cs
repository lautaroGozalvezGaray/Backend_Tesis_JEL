using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("ubicacion")]
public partial class ubicacion
{
    [Key]
    public int idubicacion { get; set; }

    public int? dni { get; set; }

    [StringLength(255)]
    public string domicilio { get; set; }

    [StringLength(50)]
    public string barrio { get; set; }

    [StringLength(50)]
    public string localidad { get; set; }

    [InverseProperty("idubicacionNavigation")]
    public virtual ICollection<paciente> pacientes { get; set; } = new List<paciente>();
}
