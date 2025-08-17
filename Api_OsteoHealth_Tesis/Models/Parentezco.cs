using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("parentezco")]
public partial class parentezco
{
    [Key]
    public int idparentezco { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idparentezcoNavigation")]
    public virtual ICollection<tipo_enfermedad_hereditarium> tipo_enfermedad_hereditaria { get; set; } = new List<tipo_enfermedad_hereditarium>();
}
