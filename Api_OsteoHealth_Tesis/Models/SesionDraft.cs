// Models/SesionDraft.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_OsteoHealth_Tesis.Models
{
    [Table("sesion_drafts")]
    public class SesionDraft
    {
        [Key] public Guid id { get; set; }
        [Required] public Guid SesionId { get; set; }
        [Required] public int Step { get; set; }
        [Required] public string DataJson { get; set; } = "{}";
        [Required]
        [Column(TypeName = "timestamp with time zone")] // "timestamptz"
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
