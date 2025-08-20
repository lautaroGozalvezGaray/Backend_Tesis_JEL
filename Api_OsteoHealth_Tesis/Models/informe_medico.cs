using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Table("informe_medico")]
public partial class informe_medico
{
    [Key]
    public int idinformemedico { get; set; }

    public int idantecedenosologico { get; set; }

    [StringLength(255)]
    public string rutaarchivo { get; set; }

    public DateOnly? fecha { get; set; }

    [ForeignKey("idantecedenosologico")]
    [InverseProperty("informe_medicos")]
    public virtual estudios_nosocologico idantecedenosologicoNavigation { get; set; }
}
