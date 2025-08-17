using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("sueno")]
public partial class sueno
{
    [Key]
    public int idsueno { get; set; }

    public int idsesion { get; set; }

    public int? horassueno { get; set; }

    public int idcalidadpercibidasueno { get; set; }

    public TimeOnly? horariohabitual { get; set; }

    [ForeignKey("idcalidadpercibidasueno")]
    [InverseProperty("suenos")]
    public virtual calidad_percibida_sueno idcalidadpercibidasuenoNavigation { get; set; }

    [InverseProperty("idsuenoNavigation")]
    public virtual ICollection<sesion> sesions { get; set; } = new List<sesion>();
}
