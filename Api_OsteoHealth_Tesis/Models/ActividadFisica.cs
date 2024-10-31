using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class ActividadFisica
{
    public int IdActividadFisica { get; set; }

    public int IdSesion { get; set; }

    public decimal? TiempoDedicadoXsession { get; set; }

    public string TiempoVigencia { get; set; }

    public int? CantidadLapso { get; set; }

    public int? IdFrecuenciaLapso { get; set; }

    public int? IdTipoActividadFisica { get; set; }

    public virtual FrecuenciaLapso IdFrecuenciaLapsoNavigation { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual TipoActividadFisica IdTipoActividadFisicaNavigation { get; set; }
}
