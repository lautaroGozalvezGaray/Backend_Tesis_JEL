using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sintoma_clinico")]
public partial class sintoma_clinico
{
    [Key]
    public int idsintomaclinico { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idsintomaclinicoNavigation")]
    public virtual ICollection<sesion> sesions { get; set; } = new List<sesion>();
}
