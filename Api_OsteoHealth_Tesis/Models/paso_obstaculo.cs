using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("paso_obstaculo")]
public partial class paso_obstaculo
{
    [Key]
    public int idpasoobstaculo { get; set; }

    public int idevaluacionbiomecanica { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [Precision(5, 2)]
    public decimal? desempeoderecho { get; set; }

    [Precision(5, 2)]
    public decimal? desempeoizquierdo { get; set; }

    [ForeignKey("idevaluacionbiomecanica")]
    [InverseProperty("paso_obstaculos")]
    public virtual evaluacion_biomecanica idevaluacionbiomecanicaNavigation { get; set; }
}
