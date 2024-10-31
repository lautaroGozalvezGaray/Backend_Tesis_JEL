using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class SindromeDetectado
{
    public int IdSindromeDetectado { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<EscuchaOsteopatica> EscuchaOsteopaticas { get; set; } = new List<EscuchaOsteopatica>();
}
