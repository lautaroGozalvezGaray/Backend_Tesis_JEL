using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("estabilidad_rotacion")]
public partial class estabilidad_rotacion
{
    [Key]
    public int idestabilidadrotacion { get; set; }

    public int idevaluacionbiomecanica { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [Precision(5, 2)]
    public decimal? derecho { get; set; }

    [Precision(5, 2)]
    public decimal? izquierdo { get; set; }

    [Precision(5, 2)]
    public decimal? desempeoderecho { get; set; }

    [Precision(5, 2)]
    public decimal? desempeoizquierdo { get; set; }

    [ForeignKey("idevaluacionbiomecanica")]
    [InverseProperty("estabilidad_rotacions")]
    public virtual evaluacion_biomecanica idevaluacionbiomecanicaNavigation { get; set; }
}
