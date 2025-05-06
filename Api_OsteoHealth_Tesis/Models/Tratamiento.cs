using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class tratamiento
{
    [Key]
    public int idtratamiento { get; set; }

    public int idantecedenosologico { get; set; }

    [Column("tratamiento")]
    [StringLength(255)]
    public string tratamiento1 { get; set; }

    [StringLength(255)]
    public string resultado { get; set; }

    [ForeignKey("idantecedenosologico")]
    [InverseProperty("tratamientos")]
    public virtual estudios_nosocologico idantecedenosologicoNavigation { get; set; }
}
