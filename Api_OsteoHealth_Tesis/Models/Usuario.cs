using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public string Rol { get; set; }
}
