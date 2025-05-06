using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("metodo_anticonceptivo")]
public partial class metodo_anticonceptivo
{
    [Key]
    public int idmetodo { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idmetodoNavigation")]
    public virtual ICollection<antecedentes_tocoginecologico> antecedentes_tocoginecologicos { get; set; } = new List<antecedentes_tocoginecologico>();
}
