using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class EstiloActividadLaboral
{
    public int IdEstiloActividadLaboral { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<ActividadLaboralProfesional> ActividadLaboralProfesionals { get; set; } = new List<ActividadLaboralProfesional>();
}
