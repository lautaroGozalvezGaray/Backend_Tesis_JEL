using System;
using System.Collections.Generic;

namespace Api_OsteoHealth_Tesis.Models;

public partial class Paciente
{
    public int Dni { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public int? Edad { get; set; }

    public string Estado { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Altura { get; set; }

    public int? Sexo { get; set; }

    public string Telefono { get; set; }

    public string Email { get; set; }

    public int IdObraSocial { get; set; }

    public int IdImagen { get; set; }

    public int IdUbicacion { get; set; }

    public int IdInformacionAdicional { get; set; }

    public int IdEnfermedadHereditaria { get; set; }

    public int IdAntecedeToco { get; set; }

    public virtual ICollection<AntecedentesTocoginecologico> AntecedentesTocoginecologicos { get; set; } = new List<AntecedentesTocoginecologico>();

    public virtual ImagenPaciente IdImagenNavigation { get; set; }

    public virtual InformacionAdicional IdInformacionAdicionalNavigation { get; set; }

    public virtual ObraSocial IdObraSocialNavigation { get; set; }

    public virtual Ubicacion IdUbicacionNavigation { get; set; }

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();

    public virtual Sexo SexoNavigation { get; set; }

    public virtual ICollection<TipoEnfermedadHereditarium> TipoEnfermedadHereditaria { get; set; } = new List<TipoEnfermedadHereditarium>();
}
