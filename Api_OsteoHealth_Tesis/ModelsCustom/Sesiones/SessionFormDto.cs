namespace Api_OsteoHealth_Tesis.ModelsCustom.Sesiones
{
    public class SessionFormDto
    {
        public string? pacienteid { get; set; }
        public string fecha { get; set; } = string.Empty;
        public string? profesionalid { get; set; }
        public string? DerivadoPor { get; set; }

        public object Caracteristicas { get; set; } = new { };
        public object Sueno { get; set; } = new { };
        public object Digestion { get; set; } = new { };
        public object Habitos { get; set; } = new { };

        public object? ActividadDraft { get; set; }
        public object? LaboralDraft { get; set; }
        public object? AlimentoDraft { get; set; }
        public object? ToxicoDraft { get; set; }
    }
}
