using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class tipo_estudio
{
    [Key]
    public int idtipoestudios { get; set; }

    public int idantecedenosologico { get; set; }

    [StringLength(50)]
    public string nombre { get; set; }

    [ForeignKey("idantecedenosologico")]
    [InverseProperty("tipo_estudios")]
    public virtual estudios_nosocologico idantecedenosologicoNavigation { get; set; }
}
