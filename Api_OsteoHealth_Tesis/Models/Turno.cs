using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public int? IdPaciente { get; set; }

    public string DiaSemana { get; set; }

    public TimeOnly? Hora { get; set; }

    public string EstadoTurno { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; }
}
