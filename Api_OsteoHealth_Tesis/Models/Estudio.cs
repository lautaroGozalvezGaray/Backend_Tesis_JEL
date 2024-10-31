using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Estudio
{
    public int IdEstudios { get; set; }

    public int IdAntecedeNosologico { get; set; }

    public string RutaArchivo { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual EstudiosNosocologico IdAntecedeNosologicoNavigation { get; set; }
}
