using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class ImagenPaciente
{
    public int IdImagen { get; set; }

    public byte[] Imagen { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
