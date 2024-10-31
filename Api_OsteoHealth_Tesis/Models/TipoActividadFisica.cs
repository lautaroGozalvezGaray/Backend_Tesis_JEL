using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TipoActividadFisica
{
    public int IdTipoActividadFisica { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<ActividadFisica> ActividadFisicas { get; set; } = new List<ActividadFisica>();
}
