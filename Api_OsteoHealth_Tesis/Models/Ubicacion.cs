using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Ubicacion
{
    public int IdUbicacion { get; set; }

    public int? Dni { get; set; }

    public string Domicilio { get; set; }

    public string Barrio { get; set; }

    public string Localidad { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
