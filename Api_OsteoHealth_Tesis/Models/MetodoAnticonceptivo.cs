using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class MetodoAnticonceptivo
{
    public int IdMetodo { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<AntecedentesTocoginecologico> AntecedentesTocoginecologicos { get; set; } = new List<AntecedentesTocoginecologico>();
}
