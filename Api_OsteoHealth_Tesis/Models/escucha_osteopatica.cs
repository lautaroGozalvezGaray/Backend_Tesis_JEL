using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("escucha_osteopatica")]
public partial class escucha_osteopatica
{
    [Key]
    public int idescuchaosteopatica { get; set; }

    public int idsesion { get; set; }

    [StringLength(50)]
    public string tipoafeccion { get; set; }

    public int? gradoafeccion { get; set; }

    public int idtiposestructura { get; set; }

    public int idsindromedetectado { get; set; }

    [ForeignKey("idsindromedetectado")]
    [InverseProperty("escucha_osteopaticas")]
    public virtual sindrome_detectado idsindromedetectadoNavigation { get; set; }

    [ForeignKey("idtiposestructura")]
    [InverseProperty("escucha_osteopaticas")]
    public virtual tipos_estructura idtiposestructuraNavigation { get; set; }
}
