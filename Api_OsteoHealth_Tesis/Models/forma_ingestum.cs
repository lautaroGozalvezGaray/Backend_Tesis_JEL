using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class forma_ingestum
{
    [Key]
    public int idformaingesta { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idformaingestaNavigation")]
    public virtual ICollection<alimentacion> alimentacions { get; set; } = new List<alimentacion>();
}
