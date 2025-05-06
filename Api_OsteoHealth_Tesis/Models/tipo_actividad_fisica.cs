using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipo_actividad_fisica")]
public partial class tipo_actividad_fisica
{
    [Key]
    public int idtipoactividadfisica { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idtipoactividadfisicaNavigation")]
    public virtual ICollection<actividad_fisica> actividad_fisicas { get; set; } = new List<actividad_fisica>();
}
