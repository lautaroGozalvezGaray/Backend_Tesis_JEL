using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipos_estructura")]
public partial class tipos_estructura
{
    [Key]
    public int idtiposestructura { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idtiposestructuraNavigation")]
    public virtual ICollection<escucha_osteopatica> escucha_osteopaticas { get; set; } = new List<escucha_osteopatica>();

    [InverseProperty("idtiposestructuraNavigation")]
    public virtual ICollection<tratamiento_efectuado> tratamiento_efectuados { get; set; } = new List<tratamiento_efectuado>();
}
