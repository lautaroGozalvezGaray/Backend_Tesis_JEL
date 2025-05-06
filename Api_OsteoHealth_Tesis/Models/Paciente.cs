using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("paciente")]
public partial class paciente
{
    [Key]
    public int dni { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [StringLength(50)]
    public string apellido { get; set; }

    public DateOnly? fechaingreso { get; set; }

    public DateOnly? fechanacimiento { get; set; }

    public int? edad { get; set; }

    [StringLength(20)]
    public string estado { get; set; }

    [Precision(5, 2)]
    public decimal? peso { get; set; }

    [Precision(5, 2)]
    public decimal? altura { get; set; }

    public int? sexo { get; set; }

    [StringLength(20)]
    public string telefono { get; set; }

    [StringLength(50)]
    public string email { get; set; }

    public int idobrasocial { get; set; }

    public int idimagen { get; set; }

    public int idubicacion { get; set; }

    public int idinformacionadicional { get; set; }

    public int idenfermedadhereditaria { get; set; }

    public int idantecedetoco { get; set; }

    [InverseProperty("dniNavigation")]
    public virtual ICollection<antecedentes_tocoginecologico> antecedentes_tocoginecologicos { get; set; } = new List<antecedentes_tocoginecologico>();

    [ForeignKey("idimagen")]
    [InverseProperty("pacientes")]
    public virtual imagen_paciente idimagenNavigation { get; set; }

    [ForeignKey("idinformacionadicional")]
    [InverseProperty("pacientes")]
    public virtual informacion_adicional idinformacionadicionalNavigation { get; set; }

    [ForeignKey("idobrasocial")]
    [InverseProperty("pacientes")]
    public virtual obra_social idobrasocialNavigation { get; set; }

    [ForeignKey("idubicacion")]
    [InverseProperty("pacientes")]
    public virtual ubicacion idubicacionNavigation { get; set; }

    [InverseProperty("dniNavigation")]
    public virtual ICollection<sesion> sesions { get; set; } = new List<sesion>();

    [ForeignKey("sexo")]
    [InverseProperty("pacientes")]
    public virtual sexo sexoNavigation { get; set; }

    [InverseProperty("dniNavigation")]
    public virtual ICollection<tipo_enfermedad_hereditarium> tipo_enfermedad_hereditaria { get; set; } = new List<tipo_enfermedad_hereditarium>();
}
