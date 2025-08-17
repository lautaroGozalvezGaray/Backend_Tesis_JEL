using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

[Index("username", Name = "users_email_key", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public Guid IdUsuario { get; set; }

    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }

    [Column(TypeName = "character varying")]
    public string Rol { get; set; }

    [InverseProperty("idusuarioNavigation")]
    public virtual ICollection<turno> turnos { get; set; } = new List<turno>();
}
