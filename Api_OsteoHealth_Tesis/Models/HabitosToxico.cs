using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class HabitosToxico
{
    public int IdHabitosToxicos { get; set; }

    public int IdSesion { get; set; }

    public int? CantidadEnLapso { get; set; }

    public string TiempoVigencia { get; set; }

    public int IdTipoHabitoToxico { get; set; }

    public int IdSintomatologia { get; set; }

    public int IdFrecuenciaLapso { get; set; }

    public virtual FrecuenciaLapso IdFrecuenciaLapsoNavigation { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual Sintomatologium IdSintomatologiaNavigation { get; set; }

    public virtual TipoHabitoToxico IdTipoHabitoToxicoNavigation { get; set; }
}
