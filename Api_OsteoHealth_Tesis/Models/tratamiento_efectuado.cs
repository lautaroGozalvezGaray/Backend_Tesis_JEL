using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tratamiento_efectuado")]
public partial class tratamiento_efectuado
{
    [Key]
    public int idtratamientoefectuado { get; set; }

    public int idsesion { get; set; }

    public int idtiposestructura { get; set; }

    [StringLength(255)]
    public string tecnicautilizada { get; set; }

    [StringLength(255)]
    public string respuestaatecnica { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("tratamiento_efectuados")]
    public virtual sesion idsesionNavigation { get; set; }

    [ForeignKey("idtiposestructura")]
    [InverseProperty("tratamiento_efectuados")]
    public virtual tipos_estructura idtiposestructuraNavigation { get; set; }
}
