using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TiposEstructura
{
    public int IdTiposEstructura { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<EscuchaOsteopatica> EscuchaOsteopaticas { get; set; } = new List<EscuchaOsteopatica>();

    public virtual ICollection<TratamientoEfectuado> TratamientoEfectuados { get; set; } = new List<TratamientoEfectuado>();
}
