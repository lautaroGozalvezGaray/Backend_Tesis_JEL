using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipo_habito_toxico")]
public partial class tipo_habito_toxico
{
    [Key]
    public int idtipohabitotoxico { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idtipohabitotoxicoNavigation")]
    public virtual ICollection<habitos_toxico> habitos_toxicos { get; set; } = new List<habitos_toxico>();
}
