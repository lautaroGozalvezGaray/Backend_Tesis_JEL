using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class CalidadPercibidaSueno
{
    public int IdCalidadPercibidaSueno { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Sueno> Suenos { get; set; } = new List<Sueno>();
}
