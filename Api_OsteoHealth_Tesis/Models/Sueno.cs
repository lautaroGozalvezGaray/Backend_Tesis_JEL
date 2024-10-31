using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Sueno
{
    public int IdSueno { get; set; }

    public int IdSesion { get; set; }

    public int? HorasSueno { get; set; }

    public int IdCalidadPercibidaSueno { get; set; }

    public TimeOnly? HorarioHabitual { get; set; }

    public virtual CalidadPercibidaSueno IdCalidadPercibidaSuenoNavigation { get; set; }

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();
}
