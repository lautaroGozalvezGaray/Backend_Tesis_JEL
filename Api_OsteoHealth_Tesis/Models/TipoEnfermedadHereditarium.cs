using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TipoEnfermedadHereditarium
{
    public int IdEnfermedadHereditaria { get; set; }

    public int? Dni { get; set; }

    public int? Grado { get; set; }

    public int IdEnfermedad { get; set; }

    public int IdParentezco { get; set; }

    public virtual Paciente DniNavigation { get; set; }

    public virtual TipoEnfermedad IdEnfermedadNavigation { get; set; }

    public virtual Parentezco IdParentezcoNavigation { get; set; }
}
