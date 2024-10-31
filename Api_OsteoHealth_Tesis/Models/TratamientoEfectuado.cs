using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class TratamientoEfectuado
{
    public int IdTratamientoEfectuado { get; set; }

    public int IdSesion { get; set; }

    public int IdTiposEstructura { get; set; }

    public string TecnicaUtilizada { get; set; }

    public string RespuestaAtecnica { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual TiposEstructura IdTiposEstructuraNavigation { get; set; }
}
