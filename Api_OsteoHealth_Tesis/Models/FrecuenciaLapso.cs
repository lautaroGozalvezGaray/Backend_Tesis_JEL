using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class FrecuenciaLapso
{
    public int IdFrecuenciaLapso { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<ActividadFisica> ActividadFisicas { get; set; } = new List<ActividadFisica>();

    public virtual ICollection<ActividadLaboralProfesional> ActividadLaboralProfesionals { get; set; } = new List<ActividadLaboralProfesional>();

    public virtual ICollection<Digestion> Digestions { get; set; } = new List<Digestion>();

    public virtual ICollection<HabitosToxico> HabitosToxicos { get; set; } = new List<HabitosToxico>();
}
