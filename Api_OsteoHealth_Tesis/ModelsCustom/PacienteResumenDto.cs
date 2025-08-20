using System;

namespace Api_OsteoHealth_Tesis.ModelsCustom
{
    public class PacienteResumenDto
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateOnly? fechaingreso { get; set; }
    }
}
