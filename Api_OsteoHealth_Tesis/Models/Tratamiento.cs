using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public int IdAntecedeNosologico { get; set; }

    public string Tratamiento1 { get; set; }

    public string Resultado { get; set; }

    public virtual EstudiosNosocologico IdAntecedeNosologicoNavigation { get; set; }
}
