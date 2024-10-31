using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Parentezco
{
    public int IdParentezco { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<TipoEnfermedadHereditarium> TipoEnfermedadHereditaria { get; set; } = new List<TipoEnfermedadHereditarium>();
}
