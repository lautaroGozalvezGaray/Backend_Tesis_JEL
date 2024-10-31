using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class SintomaDigestion
{
    public int IdSintomaDigestion { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Digestion> Digestions { get; set; } = new List<Digestion>();
}
