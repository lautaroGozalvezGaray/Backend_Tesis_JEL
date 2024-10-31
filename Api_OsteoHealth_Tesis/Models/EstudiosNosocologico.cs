using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class EstudiosNosocologico
{
    public int IdAntecedeNosologico { get; set; }

    public int IdSesion { get; set; }

    public int IdTipoEstudios { get; set; }

    public int IdInformeMedico { get; set; }

    public int IdEstudios { get; set; }

    public int IdTratamiento { get; set; }

    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual ICollection<InformeMedico> InformeMedicos { get; set; } = new List<InformeMedico>();

    public virtual ICollection<TipoEstudio> TipoEstudios { get; set; } = new List<TipoEstudio>();

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
