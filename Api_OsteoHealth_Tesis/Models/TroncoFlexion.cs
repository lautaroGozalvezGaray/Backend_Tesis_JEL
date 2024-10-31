using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TroncoFlexion
{
    public int IdTroncoFlexion { get; set; }

    public int IdEvaluacionBiomecanica { get; set; }

    public string Nombre { get; set; }

    public decimal? Puntuacion { get; set; }

    public decimal? Desempeno { get; set; }

    public virtual EvaluacionBiomecanica IdEvaluacionBiomecanicaNavigation { get; set; }
}
