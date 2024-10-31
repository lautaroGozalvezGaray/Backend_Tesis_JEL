using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Caracteristica
{
    public int IdCaracteristicas { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Altura { get; set; }

    public decimal? PorcentajeGrasa { get; set; }

    public decimal? PorcentajeMasaMuscular { get; set; }

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();
}
