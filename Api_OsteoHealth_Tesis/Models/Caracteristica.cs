using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class caracteristica
{
    [Key]
    public int idcaracteristicas { get; set; }

    public int? edad { get; set; }

    [Precision(5, 2)]
    public decimal? peso { get; set; }

    [Precision(5, 2)]
    public decimal? altura { get; set; }

    [Precision(5, 2)]
    public decimal? porcentajengrasa { get; set; }

    [Precision(5, 2)]
    public decimal? porcentajemasamuscular { get; set; }

    [InverseProperty("idcaracteristicasNavigation")]
    public virtual ICollection<sesion> sesions { get; set; } = new List<sesion>();
}
