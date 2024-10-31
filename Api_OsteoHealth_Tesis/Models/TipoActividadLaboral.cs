using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TipoActividadLaboral
{
    public int IdTipoActividadLaboral { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<ActividadLaboralProfesional> ActividadLaboralProfesionals { get; set; } = new List<ActividadLaboralProfesional>();
}
