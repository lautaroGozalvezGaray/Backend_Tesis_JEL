using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class AntecedentesTocoginecologico
{
    public int IdAntecedeToco { get; set; }

    public int? Dni { get; set; }

    public byte? Embarazo { get; set; }

    public byte? Parto { get; set; }

    public byte? Cesaria { get; set; }

    public byte? SindromePreMens { get; set; }

    public byte? Menopausia { get; set; }

    public int IdMetodo { get; set; }

    public virtual Paciente DniNavigation { get; set; }

    public virtual MetodoAnticonceptivo IdMetodoNavigation { get; set; }
}
