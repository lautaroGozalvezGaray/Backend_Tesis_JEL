using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class InformacionAdicional
{
    public int IdInformacionAdicional { get; set; }

    public int? Dni { get; set; }

    public string TiempoAfeccion { get; set; }

    public string Motivo { get; set; }

    public string Referencia { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
