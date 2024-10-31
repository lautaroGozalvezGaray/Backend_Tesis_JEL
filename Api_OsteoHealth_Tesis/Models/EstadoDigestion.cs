using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class EstadoDigestion
{
    public int IdEstadoDigestion { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Digestion> Digestions { get; set; } = new List<Digestion>();

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();
}
