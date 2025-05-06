using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("calidad_percibida_sueno")]
public partial class calidad_percibida_sueno
{
    [Key]
    public int idcalidadpercibidasueno { get; set; }

    [Required]
    [StringLength(50)]
    public string nombre { get; set; }

    [InverseProperty("idcalidadpercibidasuenoNavigation")]
    public virtual ICollection<sueno> suenos { get; set; } = new List<sueno>();
}
