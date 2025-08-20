using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sentadilla")]
public partial class sentadilla
{
    [Key]
    public int idsentadilla { get; set; }

    public int idevaluacionbiomecanica { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [Precision(5, 2)]
    public decimal? puntuacion { get; set; }

    [Precision(5, 2)]
    public decimal? desempeno { get; set; }

    [ForeignKey("idevaluacionbiomecanica")]
    [InverseProperty("sentadillas")]
    public virtual evaluacion_biomecanica idevaluacionbiomecanicaNavigation { get; set; }
}
