﻿using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class ObraSocial
{
    public int IdObraSocial { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
