using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class EscuchaOsteopatica
{
    public int IdEscuchaOsteopatica { get; set; }

    public int IdSesion { get; set; }

    public string TipoAfeccion { get; set; }

    public int? GradoAfeccion { get; set; }

    public int IdTiposEstructura { get; set; }

    public int IdSindromeDetectado { get; set; }

    public virtual SindromeDetectado IdSindromeDetectadoNavigation { get; set; }

    public virtual TiposEstructura IdTiposEstructuraNavigation { get; set; }
}
