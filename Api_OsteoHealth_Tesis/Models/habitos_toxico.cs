using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class habitos_toxico
{
    [Key]
    public int idhabitostoxicos { get; set; }

    public int idsesion { get; set; }

    public int? cantidadenlapso { get; set; }

    [StringLength(50)]
    public string tiempovigencia { get; set; }

    public int idtipohabitotoxico { get; set; }

    public int idsintomatologia { get; set; }

    public int idfrecuencialapso { get; set; }

    [ForeignKey("idfrecuencialapso")]
    [InverseProperty("habitos_toxicos")]
    public virtual frecuencia_lapso idfrecuencialapsoNavigation { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("habitos_toxicos")]
    public virtual sesion idsesionNavigation { get; set; }

    [ForeignKey("idsintomatologia")]
    [InverseProperty("habitos_toxicos")]
    public virtual sintomatologium idsintomatologiaNavigation { get; set; }

    [ForeignKey("idtipohabitotoxico")]
    [InverseProperty("habitos_toxicos")]
    public virtual tipo_habito_toxico idtipohabitotoxicoNavigation { get; set; }
}
