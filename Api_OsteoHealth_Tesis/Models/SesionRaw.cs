using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Api_OsteoHealth_Tesis.Models
{
    [Table("sesiones_raw")]
    public class SesionRaw
    {
        [Key] public Guid id { get; set; }
        [Required] public DateTimeOffset createdat { get; set; }  // antes: DateTime
        [Required] public JsonDocument payloadjson { get; set; } = JsonDocument.Parse("{}");
        public string? pacienteid { get; set; }
        public string? fecha { get; set; }
        public string? profesionalid { get; set; }
    }
}
