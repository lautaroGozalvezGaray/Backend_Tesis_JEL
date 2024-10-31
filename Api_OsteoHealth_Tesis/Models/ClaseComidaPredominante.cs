using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class ClaseComidaPredominante
{
    public int IdClaseComidaPredominante { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Alimentacion> Alimentacions { get; set; } = new List<Alimentacion>();
}
