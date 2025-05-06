using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class sintomatologium
{
    [Key]
    public int idsintomatologia { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idsintomatologiaNavigation")]
    public virtual ICollection<habitos_toxico> habitos_toxicos { get; set; } = new List<habitos_toxico>();
}
