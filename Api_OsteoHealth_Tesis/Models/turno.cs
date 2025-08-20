using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("turno")]
public partial class turno
{
    [Key]
    public int dturno { get; set; }

    public DateOnly fecha { get; set; }

    public TimeOnly hora { get; set; }

    public int? duracionminutos { get; set; }

    [Required]
    [StringLength(50)]
    public string estadoturno { get; set; }

    public string observaciones { get; set; }

    public Guid idusuario { get; set; }

    public int idpaciente { get; set; }

    public string nombrepaciente { get; set; }

    public string apellidopaciente { get; set; }

    public string dnipaciente { get; set; }

    [ForeignKey("idpaciente")]
    [InverseProperty("turnos")]
    public virtual paciente idpacienteNavigation { get; set; }

    [ForeignKey("idusuario")]
    [InverseProperty("turnos")]
    public virtual Usuario idusuarioNavigation { get; set; }
}
