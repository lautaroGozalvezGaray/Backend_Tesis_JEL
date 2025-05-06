using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("clase_comida_predominante")]
public partial class clase_comida_predominante
{
    [Key]
    public int idclasecomidapredominante { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idclasecomidapredominanteNavigation")]
    public virtual ICollection<alimentacion> alimentacions { get; set; } = new List<alimentacion>();
}
