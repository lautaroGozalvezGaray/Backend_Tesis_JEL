using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TipoEstudio
{
    public int IdTipoEstudios { get; set; }

    public int IdAntecedeNosologico { get; set; }

    public string Nombre { get; set; }

    public virtual EstudiosNosocologico IdAntecedeNosologicoNavigation { get; set; }
}
