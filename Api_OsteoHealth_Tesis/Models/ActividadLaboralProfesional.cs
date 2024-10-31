using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class ActividadLaboralProfesional
{
    public int IdActividadLaboralProfesional { get; set; }

    public int IdSesion { get; set; }

    public int? CantidadLapso { get; set; }

    public string TiempoVigencia { get; set; }

    public int IdFrecuenciaLapso { get; set; }

    public int IdEstiloActividadLaboral { get; set; }

    public int IdTipoActividadLaboral { get; set; }

    public virtual EstiloActividadLaboral IdEstiloActividadLaboralNavigation { get; set; }

    public virtual FrecuenciaLapso IdFrecuenciaLapsoNavigation { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual TipoActividadLaboral IdTipoActividadLaboralNavigation { get; set; }
}
