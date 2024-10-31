using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class EvaluacionBiomecanica
{
    public int IdEvaluacionBiomecanica { get; set; }

    public int IdSesion { get; set; }

    public virtual ICollection<DesplanteLinea> DesplanteLineas { get; set; } = new List<DesplanteLinea>();

    public virtual ICollection<EstabilidadRotacion> EstabilidadRotacions { get; set; } = new List<EstabilidadRotacion>();

    public virtual Sesion IdSesionNavigation { get; set; }

    public virtual ICollection<LevantamientoPierna> LevantamientoPiernas { get; set; } = new List<LevantamientoPierna>();

    public virtual ICollection<MovilidadHombro> MovilidadHombros { get; set; } = new List<MovilidadHombro>();

    public virtual ICollection<PasoObstaculo> PasoObstaculos { get; set; } = new List<PasoObstaculo>();

    public virtual ICollection<Sentadilla> Sentadillas { get; set; } = new List<Sentadilla>();

    public virtual ICollection<TroncoFlexion> TroncoFlexions { get; set; } = new List<TroncoFlexion>();
}
