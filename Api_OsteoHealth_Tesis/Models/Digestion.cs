using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Digestion
{
    public int IdDigestion { get; set; }

    public int IdSesion { get; set; }

    public int? CantidadLapso { get; set; }

    public int IdSintomaDigestion { get; set; }

    public int IdFrecuenciaLapso { get; set; }

    public int IdEstadoDigestion { get; set; }

    public virtual EstadoDigestion IdEstadoDigestionNavigation { get; set; }

    public virtual FrecuenciaLapso IdFrecuenciaLapsoNavigation { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual SintomaDigestion IdSintomaDigestionNavigation { get; set; }
}
