using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipo_enfermedad")]
public partial class tipo_enfermedad
{
    [Key]
    public int idenfermedad { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idenfermedadNavigation")]
    public virtual ICollection<tipo_enfermedad_hereditarium> tipo_enfermedad_hereditaria { get; set; } = new List<tipo_enfermedad_hereditarium>();
}

public class TipoEnfermedadDto
{
    public int idenfermedad { get; set; }
    public string nombre { get; set; }
}
