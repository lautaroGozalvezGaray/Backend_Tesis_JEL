using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("alimentacion")]
public partial class alimentacion
{
    [Key]
    public int idalimentacion { get; set; }

    public int idsesion { get; set; }

    public int? porcentaje { get; set; }

    [StringLength(50)]
    public string nivelcoccion { get; set; }

    public int idformaingesta { get; set; }

    public int idcomidapredominante { get; set; }

    public int idclasecomidapredominante { get; set; }

    [ForeignKey("idclasecomidapredominante")]
    [InverseProperty("alimentacions")]
    public virtual clase_comida_predominante idclasecomidapredominanteNavigation { get; set; }

    [ForeignKey("idcomidapredominante")]
    [InverseProperty("alimentacions")]
    public virtual comida_predominante idcomidapredominanteNavigation { get; set; }

    [ForeignKey("idformaingesta")]
    [InverseProperty("alimentacions")]
    public virtual forma_ingestum idformaingestaNavigation { get; set; }

    [ForeignKey("idsesion")]
    [InverseProperty("alimentacions")]
    public virtual sesion idsesionNavigation { get; set; }
}
