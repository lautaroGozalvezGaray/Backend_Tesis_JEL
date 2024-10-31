using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class PasoObstaculo
{
    public int IdPasoObstaculo { get; set; }

    public int IdEvaluacionBiomecanica { get; set; }

    public string Nombre { get; set; }

    public decimal? DesempenoDerecho { get; set; }

    public decimal? DesempenoIzquierdo { get; set; }

    public virtual EvaluacionBiomecanica IdEvaluacionBiomecanicaNavigation { get; set; }
}
