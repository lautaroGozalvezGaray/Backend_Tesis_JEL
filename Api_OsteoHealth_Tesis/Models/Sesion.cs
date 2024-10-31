using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Sesion
{
    public int IdSesion { get; set; }

    public int? Dni { get; set; }

    public DateOnly? Fecha { get; set; }

    public int IdCaracteristicas { get; set; }

    public int IdEstadoDigestion { get; set; }

    public int IdSueno { get; set; }

    public int IdAlimentacion { get; set; }

    public int IdHabitoToxico { get; set; }

    public int IdActividadLaboralProfesional { get; set; }

    public int IdSintomaClinico { get; set; }

    public int IdEscuchaOsteopatica { get; set; }

    public virtual ICollection<ActividadFisica> ActividadFisicas { get; set; } = new List<ActividadFisica>();

    public virtual ICollection<ActividadLaboralProfesional> ActividadLaboralProfesionals { get; set; } = new List<ActividadLaboralProfesional>();

    public virtual ICollection<Alimentacion> Alimentacions { get; set; } = new List<Alimentacion>();

    public virtual ICollection<Digestion> Digestions { get; set; } = new List<Digestion>();

    public virtual Paciente DniNavigation { get; set; }

    public virtual ICollection<EstudiosNosocologico> EstudiosNosocologicos { get; set; } = new List<EstudiosNosocologico>();

    public virtual ICollection<EvaluacionBiomecanica> EvaluacionBiomecanicas { get; set; } = new List<EvaluacionBiomecanica>();

    public virtual ICollection<HabitosToxico> HabitosToxicos { get; set; } = new List<HabitosToxico>();

    public virtual Caracteristica IdCaracteristicasNavigation { get; set; }

    public virtual EstadoDigestion IdEstadoDigestionNavigation { get; set; }

    public virtual Sueno IdSuenoNavigation { get; set; }

    public virtual ICollection<TratamientoEfectuado> TratamientoEfectuados { get; set; } = new List<TratamientoEfectuado>();
}
