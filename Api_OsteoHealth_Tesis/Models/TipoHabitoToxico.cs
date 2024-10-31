using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TipoHabitoToxico
{
    public int IdTipoHabitoToxico { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<HabitosToxico> HabitosToxicos { get; set; } = new List<HabitosToxico>();
}
