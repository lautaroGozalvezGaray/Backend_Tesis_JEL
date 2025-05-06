using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sindrome_detectado")]
public partial class sindrome_detectado
{
    [Key]
    public int idsindromedetectado { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idsindromedetectadoNavigation")]
    public virtual ICollection<escucha_osteopatica> escucha_osteopaticas { get; set; } = new List<escucha_osteopatica>();
}
