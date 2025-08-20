using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_OsteoHealth_Tesis.Models;

[Table("antecedentes_tocoginecologicos")]
public partial class antecedentes_tocoginecologicos
{
    [Key]
    public int idantecedetoco { get; set; }

    public int? dni { get; set; }

    public short? embarazo { get; set; }

    public short? parto { get; set; }

    public short? cesaria { get; set; }

    public short? sindromepremens { get; set; }

    public short? menopausia { get; set; }

    public int? idmetodo { get; set; }

    [ForeignKey("dni")]
    [InverseProperty("antecedentes_tocoginecologicos")]
    public virtual paciente dniNavigation { get; set; }

    [ForeignKey("idmetodo")]
    [InverseProperty("antecedentes_tocoginecologicos")]
    public virtual metodo_anticonceptivo idmetodoNavigation { get; set; }
}
