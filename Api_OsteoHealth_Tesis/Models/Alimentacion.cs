using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Alimentacion
{
    public int IdAlimentacion { get; set; }

    public int IdSesion { get; set; }

    public int? Porcentaje { get; set; }

    public string NivelCoccion { get; set; }

    public int IdFormaIngesta { get; set; }

    public int IdComidaPredominante { get; set; }

    public int IdClaseComidaPredominante { get; set; }

    public virtual ClaseComidaPredominante IdClaseComidaPredominanteNavigation { get; set; }

    public virtual ComidaPredominante IdComidaPredominanteNavigation { get; set; }

    public virtual FormaIngestum IdFormaIngestaNavigation { get; set; }

    public virtual Sesion IdSesionNavigation { get; set; }
}
