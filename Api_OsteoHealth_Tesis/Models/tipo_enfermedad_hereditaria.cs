using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_OsteoHealth_Tesis.Models;

[Table("tipo_enfermedad_hereditaria")]
public partial class tipo_enfermedad_hereditaria
{
    [Key]
    public int idenfermedadhereditaria { get; set; }

    public int? dni { get; set; }

    public int? grado { get; set; }

    public int idenfermedad { get; set; }

    public int idparentezco { get; set; }

    [ForeignKey("dni")]
    [InverseProperty("tipo_enfermedad_hereditaria")]
    public virtual paciente dniNavigation { get; set; }

    [ForeignKey("idenfermedad")]
    [InverseProperty("tipo_enfermedad_hereditaria")]
    public virtual tipo_enfermedad idenfermedadNavigation { get; set; }

    [ForeignKey("idparentezco")]
    [InverseProperty("tipo_enfermedad_hereditaria")]
    public virtual parentezco idparentezcoNavigation { get; set; }
}
