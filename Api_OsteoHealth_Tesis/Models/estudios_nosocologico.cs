using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class estudios_nosocologico
{
    [Key]
    public int idantecedenosologico { get; set; }

    public int idsesion { get; set; }

    public int idtipoestudios { get; set; }

    public int idinformemedico { get; set; }

    public int idestudios { get; set; }

    public int idtratamiento { get; set; }

    [InverseProperty("idantecedenosologicoNavigation")]
    public virtual ICollection<estudio> estudios { get; set; } = new List<estudio>();

    [ForeignKey("idsesion")]
    [InverseProperty("estudios_nosocologicos")]
    public virtual sesion idsesionNavigation { get; set; }

    [InverseProperty("idantecedenosologicoNavigation")]
    public virtual ICollection<informe_medico> informe_medicos { get; set; } = new List<informe_medico>();

    [InverseProperty("idantecedenosologicoNavigation")]
    public virtual ICollection<tipo_estudio> tipo_estudios { get; set; } = new List<tipo_estudio>();

    [InverseProperty("idantecedenosologicoNavigation")]
    public virtual ICollection<tratamiento> tratamientos { get; set; } = new List<tratamiento>();
}
