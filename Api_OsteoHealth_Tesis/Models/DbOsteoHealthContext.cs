using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class DbOsteoHealthContext : DbContext
{
    public DbOsteoHealthContext()
    {
    }

    public DbOsteoHealthContext(DbContextOptions<DbOsteoHealthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadFisica> ActividadFisicas { get; set; }

    public virtual DbSet<ActividadLaboralProfesional> ActividadLaboralProfesionals { get; set; }

    public virtual DbSet<Alimentacion> Alimentacions { get; set; }

    public virtual DbSet<AntecedentesTocoginecologico> AntecedentesTocoginecologicos { get; set; }

    public virtual DbSet<CalidadPercibidaSueno> CalidadPercibidaSuenos { get; set; }

    public virtual DbSet<Caracteristica> Caracteristicas { get; set; }

    public virtual DbSet<ClaseComidaPredominante> ClaseComidaPredominantes { get; set; }

    public virtual DbSet<ComidaPredominante> ComidaPredominantes { get; set; }

    public virtual DbSet<DesplanteLinea> DesplanteLineas { get; set; }

    public virtual DbSet<Digestion> Digestions { get; set; }

    public virtual DbSet<EscuchaOsteopatica> EscuchaOsteopaticas { get; set; }

    public virtual DbSet<EstabilidadRotacion> EstabilidadRotacions { get; set; }

    public virtual DbSet<EstadoDigestion> EstadoDigestions { get; set; }

    public virtual DbSet<EstiloActividadLaboral> EstiloActividadLaborals { get; set; }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<EstudiosNosocologico> EstudiosNosocologicos { get; set; }

    public virtual DbSet<EvaluacionBiomecanica> EvaluacionBiomecanicas { get; set; }

    public virtual DbSet<FormaIngestum> FormaIngesta { get; set; }

    public virtual DbSet<FrecuenciaLapso> FrecuenciaLapsos { get; set; }

    public virtual DbSet<HabitosToxico> HabitosToxicos { get; set; }

    public virtual DbSet<ImagenPaciente> ImagenPacientes { get; set; }

    public virtual DbSet<InformacionAdicional> InformacionAdicionals { get; set; }

    public virtual DbSet<InformeMedico> InformeMedicos { get; set; }

    public virtual DbSet<LevantamientoPierna> LevantamientoPiernas { get; set; }

    public virtual DbSet<MetodoAnticonceptivo> MetodoAnticonceptivos { get; set; }

    public virtual DbSet<MovilidadHombro> MovilidadHombros { get; set; }

    public virtual DbSet<ObraSocial> ObraSocials { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Parentezco> Parentezcos { get; set; }

    public virtual DbSet<PasoObstaculo> PasoObstaculos { get; set; }

    public virtual DbSet<Sentadilla> Sentadillas { get; set; }

    public virtual DbSet<Sesion> Sesions { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<SindromeDetectado> SindromeDetectados { get; set; }

    public virtual DbSet<SintomaDigestion> SintomaDigestions { get; set; }

    public virtual DbSet<Sintomatologium> Sintomatologia { get; set; }

    public virtual DbSet<Sueno> Suenos { get; set; }

    public virtual DbSet<TipoActividadFisica> TipoActividadFisicas { get; set; }

    public virtual DbSet<TipoActividadLaboral> TipoActividadLaborals { get; set; }

    public virtual DbSet<TipoEnfermedad> TipoEnfermedads { get; set; }

    public virtual DbSet<TipoEnfermedadHereditarium> TipoEnfermedadHereditaria { get; set; }

    public virtual DbSet<TipoEstudio> TipoEstudios { get; set; }

    public virtual DbSet<TipoHabitoToxico> TipoHabitoToxicos { get; set; }

    public virtual DbSet<TipoTratamiento> TipoTratamientos { get; set; }

    public virtual DbSet<TiposEstructura> TiposEstructuras { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<TratamientoEfectuado> TratamientoEfectuados { get; set; }

    public virtual DbSet<TroncoFlexion> TroncoFlexions { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:serverdesarrollo.database.windows.net,1433;Initial Catalog=db_OsteoHealth;Persist Security Info=False;User ID=adminOsteo;Password=X&5rACWw9w&uedJ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActividadFisica>(entity =>
        {
            entity.HasKey(e => e.IdActividadFisica).HasName("PK__Activida__8A890B70E0E8B429");

            entity.ToTable("ActividadFisica");

            entity.Property(e => e.IdActividadFisica).HasColumnName("idActividadFisica");
            entity.Property(e => e.IdFrecuenciaLapso).HasColumnName("idFrecuenciaLapso");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdTipoActividadFisica).HasColumnName("idTipoActividadFisica");
            entity.Property(e => e.TiempoDedicadoXsession)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TiempoDedicadoXSession");
            entity.Property(e => e.TiempoVigencia)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFrecuenciaLapsoNavigation).WithMany(p => p.ActividadFisicas)
                .HasForeignKey(d => d.IdFrecuenciaLapso)
                .HasConstraintName("FK__Actividad__idFre__37703C52");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.ActividadFisicas)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idSes__367C1819");

            entity.HasOne(d => d.IdTipoActividadFisicaNavigation).WithMany(p => p.ActividadFisicas)
                .HasForeignKey(d => d.IdTipoActividadFisica)
                .HasConstraintName("FK__Actividad__idTip__3864608B");
        });

        modelBuilder.Entity<ActividadLaboralProfesional>(entity =>
        {
            entity.HasKey(e => e.IdActividadLaboralProfesional).HasName("PK__Activida__C3CE814E8159BAF1");

            entity.ToTable("ActividadLaboralProfesional");

            entity.Property(e => e.IdActividadLaboralProfesional).HasColumnName("idActividadLaboralProfesional");
            entity.Property(e => e.IdEstiloActividadLaboral).HasColumnName("idEstiloActividadLaboral");
            entity.Property(e => e.IdFrecuenciaLapso).HasColumnName("idFrecuenciaLapso");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdTipoActividadLaboral).HasColumnName("idTipoActividadLaboral");
            entity.Property(e => e.TiempoVigencia)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstiloActividadLaboralNavigation).WithMany(p => p.ActividadLaboralProfesionals)
                .HasForeignKey(d => d.IdEstiloActividadLaboral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idEst__40F9A68C");

            entity.HasOne(d => d.IdFrecuenciaLapsoNavigation).WithMany(p => p.ActividadLaboralProfesionals)
                .HasForeignKey(d => d.IdFrecuenciaLapso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idFre__40058253");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.ActividadLaboralProfesionals)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idSes__3F115E1A");

            entity.HasOne(d => d.IdTipoActividadLaboralNavigation).WithMany(p => p.ActividadLaboralProfesionals)
                .HasForeignKey(d => d.IdTipoActividadLaboral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__idTip__41EDCAC5");
        });

        modelBuilder.Entity<Alimentacion>(entity =>
        {
            entity.HasKey(e => e.IdAlimentacion).HasName("PK__Alimenta__9023BF7F15BB29B9");

            entity.ToTable("Alimentacion");

            entity.Property(e => e.IdAlimentacion).HasColumnName("idAlimentacion");
            entity.Property(e => e.IdClaseComidaPredominante).HasColumnName("idClaseComidaPredominante");
            entity.Property(e => e.IdComidaPredominante).HasColumnName("idComidaPredominante");
            entity.Property(e => e.IdFormaIngesta).HasColumnName("idFormaIngesta");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.NivelCoccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClaseComidaPredominanteNavigation).WithMany(p => p.Alimentacions)
                .HasForeignKey(d => d.IdClaseComidaPredominante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alimentac__idCla__2180FB33");

            entity.HasOne(d => d.IdComidaPredominanteNavigation).WithMany(p => p.Alimentacions)
                .HasForeignKey(d => d.IdComidaPredominante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alimentac__idCom__208CD6FA");

            entity.HasOne(d => d.IdFormaIngestaNavigation).WithMany(p => p.Alimentacions)
                .HasForeignKey(d => d.IdFormaIngesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alimentac__idFor__1F98B2C1");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.Alimentacions)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alimentac__idSes__1EA48E88");
        });

        modelBuilder.Entity<AntecedentesTocoginecologico>(entity =>
        {
            entity.HasKey(e => e.IdAntecedeToco).HasName("PK__Antecede__DB5EA1B3CD0A2F23");

            entity.Property(e => e.IdAntecedeToco).HasColumnName("idAntecedeToco");
            entity.Property(e => e.IdMetodo).HasColumnName("idMetodo");

            entity.HasOne(d => d.DniNavigation).WithMany(p => p.AntecedentesTocoginecologicos)
                .HasForeignKey(d => d.Dni)
                .HasConstraintName("FK__Antecedente__Dni__778AC167");

            entity.HasOne(d => d.IdMetodoNavigation).WithMany(p => p.AntecedentesTocoginecologicos)
                .HasForeignKey(d => d.IdMetodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anteceden__idMet__787EE5A0");
        });

        modelBuilder.Entity<CalidadPercibidaSueno>(entity =>
        {
            entity.HasKey(e => e.IdCalidadPercibidaSueno).HasName("PK__CalidadP__2D9B0099EB470722");

            entity.ToTable("CalidadPercibidaSueno");

            entity.Property(e => e.IdCalidadPercibidaSueno).HasColumnName("idCalidadPercibidaSueno");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Caracteristica>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristicas).HasName("PK__Caracter__8C8482C497947F59");

            entity.Property(e => e.IdCaracteristicas).HasColumnName("idCaracteristicas");
            entity.Property(e => e.Altura).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PorcentajeGrasa).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PorcentajeMasaMuscular).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<ClaseComidaPredominante>(entity =>
        {
            entity.HasKey(e => e.IdClaseComidaPredominante).HasName("PK__ClaseCom__983824AAA4DDC3B2");

            entity.ToTable("ClaseComidaPredominante");

            entity.Property(e => e.IdClaseComidaPredominante).HasColumnName("idClaseComidaPredominante");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ComidaPredominante>(entity =>
        {
            entity.HasKey(e => e.IdComidaPredominante).HasName("PK__ComidaPr__96A4B1FBE612B2E8");

            entity.ToTable("ComidaPredominante");

            entity.Property(e => e.IdComidaPredominante).HasColumnName("idComidaPredominante");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DesplanteLinea>(entity =>
        {
            entity.HasKey(e => e.IdDesplanteLinea).HasName("PK__Desplant__BD65FCC02469BFF0");

            entity.ToTable("DesplanteLinea");

            entity.Property(e => e.IdDesplanteLinea).HasColumnName("idDesplanteLinea");
            entity.Property(e => e.Derecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoDerecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoIzquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Izquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.DesplanteLineas)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Desplante__idEva__59C55456");
        });

        modelBuilder.Entity<Digestion>(entity =>
        {
            entity.HasKey(e => e.IdDigestion).HasName("PK__Digestio__8D8EA83A1837BE3E");

            entity.ToTable("Digestion");

            entity.Property(e => e.IdDigestion).HasColumnName("idDigestion");
            entity.Property(e => e.IdEstadoDigestion).HasColumnName("idEstadoDigestion");
            entity.Property(e => e.IdFrecuenciaLapso).HasColumnName("idFrecuenciaLapso");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdSintomaDigestion).HasColumnName("idSintomaDigestion");

            entity.HasOne(d => d.IdEstadoDigestionNavigation).WithMany(p => p.Digestions)
                .HasForeignKey(d => d.IdEstadoDigestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Digestion__idEst__498EEC8D");

            entity.HasOne(d => d.IdFrecuenciaLapsoNavigation).WithMany(p => p.Digestions)
                .HasForeignKey(d => d.IdFrecuenciaLapso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Digestion__idFre__489AC854");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.Digestions)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Digestion__idSes__46B27FE2");

            entity.HasOne(d => d.IdSintomaDigestionNavigation).WithMany(p => p.Digestions)
                .HasForeignKey(d => d.IdSintomaDigestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Digestion__idSin__47A6A41B");
        });

        modelBuilder.Entity<EscuchaOsteopatica>(entity =>
        {
            entity.HasKey(e => e.IdEscuchaOsteopatica).HasName("PK__EscuchaO__6FEDB0CF7CF97FB9");

            entity.ToTable("EscuchaOsteopatica");

            entity.Property(e => e.IdEscuchaOsteopatica).HasColumnName("idEscuchaOsteopatica");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdSindromeDetectado).HasColumnName("idSindromeDetectado");
            entity.Property(e => e.IdTiposEstructura).HasColumnName("idTiposEstructura");
            entity.Property(e => e.TipoAfeccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSindromeDetectadoNavigation).WithMany(p => p.EscuchaOsteopaticas)
                .HasForeignKey(d => d.IdSindromeDetectado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EscuchaOs__idSin__10566F31");

            entity.HasOne(d => d.IdTiposEstructuraNavigation).WithMany(p => p.EscuchaOsteopaticas)
                .HasForeignKey(d => d.IdTiposEstructura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EscuchaOs__idTip__0F624AF8");
        });

        modelBuilder.Entity<EstabilidadRotacion>(entity =>
        {
            entity.HasKey(e => e.IdEstabilidadRotacion).HasName("PK__Estabili__9C566965924520A1");

            entity.ToTable("EstabilidadRotacion");

            entity.Property(e => e.IdEstabilidadRotacion).HasColumnName("idEstabilidadRotacion");
            entity.Property(e => e.Derecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoDerecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoIzquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Izquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.EstabilidadRotacions)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estabilid__idEva__625A9A57");
        });

        modelBuilder.Entity<EstadoDigestion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoDigestion).HasName("PK__EstadoDi__6AEC904D614435CD");

            entity.ToTable("EstadoDigestion");

            entity.Property(e => e.IdEstadoDigestion).HasColumnName("idEstadoDigestion");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstiloActividadLaboral>(entity =>
        {
            entity.HasKey(e => e.IdEstiloActividadLaboral).HasName("PK__EstiloAc__755BDB2C5B4C1019");

            entity.ToTable("EstiloActividadLaboral");

            entity.Property(e => e.IdEstiloActividadLaboral).HasColumnName("idEstiloActividadLaboral");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudios).HasName("PK__Estudios__6C82CD16ABE21AF9");

            entity.Property(e => e.IdEstudios).HasColumnName("idEstudios");
            entity.Property(e => e.IdAntecedeNosologico).HasColumnName("idAntecedeNosologico");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAntecedeNosologicoNavigation).WithMany(p => p.Estudios)
                .HasForeignKey(d => d.IdAntecedeNosologico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudios__idAnte__2CF2ADDF");
        });

        modelBuilder.Entity<EstudiosNosocologico>(entity =>
        {
            entity.HasKey(e => e.IdAntecedeNosologico).HasName("PK__Estudios__80A1ED9B5E5817B9");

            entity.Property(e => e.IdAntecedeNosologico).HasColumnName("idAntecedeNosologico");
            entity.Property(e => e.IdEstudios).HasColumnName("idEstudios");
            entity.Property(e => e.IdInformeMedico).HasColumnName("idInformeMedico");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdTipoEstudios).HasColumnName("idTipoEstudios");
            entity.Property(e => e.IdTratamiento).HasColumnName("idTratamiento");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.EstudiosNosocologicos)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EstudiosN__idSes__245D67DE");
        });

        modelBuilder.Entity<EvaluacionBiomecanica>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacionBiomecanica).HasName("PK__Evaluaci__E705CC991BC7F8C4");

            entity.ToTable("EvaluacionBiomecanica");

            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.EvaluacionBiomecanicas)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__idSes__540C7B00");
        });

        modelBuilder.Entity<FormaIngestum>(entity =>
        {
            entity.HasKey(e => e.IdFormaIngesta).HasName("PK__FormaIng__59331B1C920DDAA1");

            entity.Property(e => e.IdFormaIngesta).HasColumnName("idFormaIngesta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrecuenciaLapso>(entity =>
        {
            entity.HasKey(e => e.IdFrecuenciaLapso).HasName("PK__Frecuenc__9939FFC1C619EB47");

            entity.ToTable("FrecuenciaLapso");

            entity.Property(e => e.IdFrecuenciaLapso).HasColumnName("idFrecuenciaLapso");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HabitosToxico>(entity =>
        {
            entity.HasKey(e => e.IdHabitosToxicos).HasName("PK__HabitosT__AE22C90724B22A30");

            entity.Property(e => e.IdHabitosToxicos).HasColumnName("idHabitosToxicos");
            entity.Property(e => e.IdFrecuenciaLapso).HasColumnName("idFrecuenciaLapso");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdSintomatologia).HasColumnName("idSintomatologia");
            entity.Property(e => e.IdTipoHabitoToxico).HasColumnName("idTipoHabitoToxico");
            entity.Property(e => e.TiempoVigencia)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFrecuenciaLapsoNavigation).WithMany(p => p.HabitosToxicos)
                .HasForeignKey(d => d.IdFrecuenciaLapso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HabitosTo__idFre__51300E55");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.HabitosToxicos)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HabitosTo__idSes__4E53A1AA");

            entity.HasOne(d => d.IdSintomatologiaNavigation).WithMany(p => p.HabitosToxicos)
                .HasForeignKey(d => d.IdSintomatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HabitosTo__idSin__503BEA1C");

            entity.HasOne(d => d.IdTipoHabitoToxicoNavigation).WithMany(p => p.HabitosToxicos)
                .HasForeignKey(d => d.IdTipoHabitoToxico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HabitosTo__idTip__4F47C5E3");
        });

        modelBuilder.Entity<ImagenPaciente>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__ImagenPa__EA9A71365DA55201");

            entity.ToTable("ImagenPaciente");

            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
        });

        modelBuilder.Entity<InformacionAdicional>(entity =>
        {
            entity.HasKey(e => e.IdInformacionAdicional).HasName("PK__Informac__94D33BE7E7282586");

            entity.ToTable("InformacionAdicional");

            entity.Property(e => e.IdInformacionAdicional)
                .ValueGeneratedNever()
                .HasColumnName("idInformacionAdicional");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Referencia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TiempoAfeccion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InformeMedico>(entity =>
        {
            entity.HasKey(e => e.IdInformeMedico).HasName("PK__InformeM__1C7824B5CDD6EA6B");

            entity.ToTable("InformeMedico");

            entity.Property(e => e.IdInformeMedico).HasColumnName("idInformeMedico");
            entity.Property(e => e.IdAntecedeNosologico).HasColumnName("idAntecedeNosologico");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAntecedeNosologicoNavigation).WithMany(p => p.InformeMedicos)
                .HasForeignKey(d => d.IdAntecedeNosologico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InformeMe__idAnt__2739D489");
        });

        modelBuilder.Entity<LevantamientoPierna>(entity =>
        {
            entity.HasKey(e => e.IdLevantamientoPierna).HasName("PK__Levantam__E2A87F93B71B5F48");

            entity.ToTable("LevantamientoPierna");

            entity.Property(e => e.IdLevantamientoPierna).HasColumnName("idLevantamientoPierna");
            entity.Property(e => e.Derecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoDerecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoIzquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Izquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.LevantamientoPiernas)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Levantami__idEva__5CA1C101");
        });

        modelBuilder.Entity<MetodoAnticonceptivo>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("PK__MetodoAn__E123E7E6FA32BDEA");

            entity.ToTable("MetodoAnticonceptivo");

            entity.Property(e => e.IdMetodo).HasColumnName("idMetodo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovilidadHombro>(entity =>
        {
            entity.HasKey(e => e.IdMovilidadHombros).HasName("PK__Movilida__8C941C3D50B49428");

            entity.Property(e => e.IdMovilidadHombros).HasColumnName("idMovilidadHombros");
            entity.Property(e => e.Derecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoDerecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoIzquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Izquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.MovilidadHombros)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movilidad__idEva__5F7E2DAC");
        });

        modelBuilder.Entity<ObraSocial>(entity =>
        {
            entity.HasKey(e => e.IdObraSocial).HasName("PK__ObraSoci__708D923C5383ED34");

            entity.ToTable("ObraSocial");

            entity.Property(e => e.IdObraSocial).HasColumnName("idObraSocial");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PK__Paciente__C03085744DFCEF23");

            entity.ToTable("Paciente");

            entity.Property(e => e.Altura).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdAntecedeToco).HasColumnName("idAntecedeToco");
            entity.Property(e => e.IdEnfermedadHereditaria).HasColumnName("idEnfermedadHereditaria");
            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
            entity.Property(e => e.IdInformacionAdicional).HasColumnName("idInformacionAdicional");
            entity.Property(e => e.IdObraSocial).HasColumnName("idObraSocial");
            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdImagenNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdImagen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__idImag__6D0D32F4");

            entity.HasOne(d => d.IdInformacionAdicionalNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdInformacionAdicional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__idInfo__6E01572D");

            entity.HasOne(d => d.IdObraSocialNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdObraSocial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__idObra__6B24EA82");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__idUbic__6C190EBB");

            entity.HasOne(d => d.SexoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.Sexo)
                .HasConstraintName("FK__Paciente__Sexo__6A30C649");
        });

        modelBuilder.Entity<Parentezco>(entity =>
        {
            entity.HasKey(e => e.IdParentezco).HasName("PK__Parentez__95B0DE5BA84EFE74");

            entity.ToTable("Parentezco");

            entity.Property(e => e.IdParentezco).HasColumnName("idParentezco");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PasoObstaculo>(entity =>
        {
            entity.HasKey(e => e.IdPasoObstaculo).HasName("PK__PasoObst__EB499D60652A4FCB");

            entity.ToTable("PasoObstaculo");

            entity.Property(e => e.IdPasoObstaculo).HasColumnName("idPasoObstaculo");
            entity.Property(e => e.DesempenoDerecho).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DesempenoIzquierdo).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.PasoObstaculos)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PasoObsta__idEva__56E8E7AB");
        });

        modelBuilder.Entity<Sentadilla>(entity =>
        {
            entity.HasKey(e => e.IdSentadilla).HasName("PK__Sentadil__653929328ED242DC");

            entity.ToTable("Sentadilla");

            entity.Property(e => e.IdSentadilla).HasColumnName("idSentadilla");
            entity.Property(e => e.Desempeno).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Puntuacion).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.Sentadillas)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sentadill__idEva__65370702");
        });

        modelBuilder.Entity<Sesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__Sesion__DB6C2DE67111DD75");

            entity.ToTable("Sesion");

            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdActividadLaboralProfesional).HasColumnName("idActividadLaboralProfesional");
            entity.Property(e => e.IdAlimentacion).HasColumnName("idAlimentacion");
            entity.Property(e => e.IdCaracteristicas).HasColumnName("idCaracteristicas");
            entity.Property(e => e.IdEscuchaOsteopatica).HasColumnName("idEscuchaOsteopatica");
            entity.Property(e => e.IdEstadoDigestion).HasColumnName("idEstadoDigestion");
            entity.Property(e => e.IdHabitoToxico).HasColumnName("idHabitoToxico");
            entity.Property(e => e.IdSintomaClinico).HasColumnName("idSintomaClinico");
            entity.Property(e => e.IdSueno).HasColumnName("idSueno");

            entity.HasOne(d => d.DniNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.Dni)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sesion__Dni__08B54D69");

            entity.HasOne(d => d.IdCaracteristicasNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.IdCaracteristicas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesion__idCaract__05D8E0BE");

            entity.HasOne(d => d.IdEstadoDigestionNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.IdEstadoDigestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesion__idEstado__06CD04F7");

            entity.HasOne(d => d.IdSuenoNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.IdSueno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesion__idSueno__07C12930");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo).HasName("PK__Sexo__C5AFCD4D7C12F528");

            entity.ToTable("Sexo");

            entity.Property(e => e.IdSexo).HasColumnName("idSexo");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SindromeDetectado>(entity =>
        {
            entity.HasKey(e => e.IdSindromeDetectado).HasName("PK__Sindrome__8875ECEDD84DF2B5");

            entity.ToTable("SindromeDetectado");

            entity.Property(e => e.IdSindromeDetectado).HasColumnName("idSindromeDetectado");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SintomaDigestion>(entity =>
        {
            entity.HasKey(e => e.IdSintomaDigestion).HasName("PK__SintomaD__ED38A5BFC4B3A8F4");

            entity.ToTable("SintomaDigestion");

            entity.Property(e => e.IdSintomaDigestion).HasColumnName("idSintomaDigestion");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sintomatologium>(entity =>
        {
            entity.HasKey(e => e.IdSintomatologia).HasName("PK__Sintomat__5960A492777AE052");

            entity.Property(e => e.IdSintomatologia).HasColumnName("idSintomatologia");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sueno>(entity =>
        {
            entity.HasKey(e => e.IdSueno).HasName("PK__Sueno__E5B736F8A10C80B2");

            entity.ToTable("Sueno");

            entity.Property(e => e.IdSueno).HasColumnName("idSueno");
            entity.Property(e => e.IdCalidadPercibidaSueno).HasColumnName("idCalidadPercibidaSueno");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");

            entity.HasOne(d => d.IdCalidadPercibidaSuenoNavigation).WithMany(p => p.Suenos)
                .HasForeignKey(d => d.IdCalidadPercibidaSueno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sueno__idCalidad__01142BA1");
        });

        modelBuilder.Entity<TipoActividadFisica>(entity =>
        {
            entity.HasKey(e => e.IdTipoActividadFisica).HasName("PK__TipoActi__6D3489C34B7E068E");

            entity.ToTable("TipoActividadFisica");

            entity.Property(e => e.IdTipoActividadFisica).HasColumnName("idTipoActividadFisica");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoActividadLaboral>(entity =>
        {
            entity.HasKey(e => e.IdTipoActividadLaboral).HasName("PK__TipoActi__BCF78BB56315B0D5");

            entity.ToTable("TipoActividadLaboral");

            entity.Property(e => e.IdTipoActividadLaboral).HasColumnName("idTipoActividadLaboral");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoEnfermedad>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedad).HasName("PK__TipoEnfe__E8DAA00A11DE263A");

            entity.ToTable("TipoEnfermedad");

            entity.Property(e => e.IdEnfermedad).HasColumnName("idEnfermedad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoEnfermedadHereditarium>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedadHereditaria).HasName("PK__TipoEnfe__AA158C912514D776");

            entity.Property(e => e.IdEnfermedadHereditaria).HasColumnName("idEnfermedadHereditaria");
            entity.Property(e => e.IdEnfermedad).HasColumnName("idEnfermedad");
            entity.Property(e => e.IdParentezco).HasColumnName("idParentezco");

            entity.HasOne(d => d.DniNavigation).WithMany(p => p.TipoEnfermedadHereditaria)
                .HasForeignKey(d => d.Dni)
                .HasConstraintName("FK__TipoEnferme__Dni__70DDC3D8");

            entity.HasOne(d => d.IdEnfermedadNavigation).WithMany(p => p.TipoEnfermedadHereditaria)
                .HasForeignKey(d => d.IdEnfermedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoEnfer__idEnf__71D1E811");

            entity.HasOne(d => d.IdParentezcoNavigation).WithMany(p => p.TipoEnfermedadHereditaria)
                .HasForeignKey(d => d.IdParentezco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoEnfer__idPar__72C60C4A");
        });

        modelBuilder.Entity<TipoEstudio>(entity =>
        {
            entity.HasKey(e => e.IdTipoEstudios).HasName("PK__TipoEstu__26FB062FF357F646");

            entity.Property(e => e.IdTipoEstudios).HasColumnName("idTipoEstudios");
            entity.Property(e => e.IdAntecedeNosologico).HasColumnName("idAntecedeNosologico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAntecedeNosologicoNavigation).WithMany(p => p.TipoEstudios)
                .HasForeignKey(d => d.IdAntecedeNosologico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoEstud__idAnt__2A164134");
        });

        modelBuilder.Entity<TipoHabitoToxico>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitoToxico).HasName("PK__TipoHabi__AB0627C782C0B941");

            entity.ToTable("TipoHabitoToxico");

            entity.Property(e => e.IdTipoHabitoToxico).HasColumnName("idTipoHabitoToxico");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoTratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoTratamiento).HasName("PK__TipoTrat__22E8F577443A0E85");

            entity.ToTable("TipoTratamiento");

            entity.Property(e => e.IdTipoTratamiento).HasColumnName("idTipoTratamiento");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposEstructura>(entity =>
        {
            entity.HasKey(e => e.IdTiposEstructura).HasName("PK__TiposEst__11D19434FEF1C9C0");

            entity.ToTable("TiposEstructura");

            entity.Property(e => e.IdTiposEstructura).HasColumnName("idTiposEstructura");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__Tratamie__6551667FD1945433");

            entity.Property(e => e.IdTratamiento).HasColumnName("idTratamiento");
            entity.Property(e => e.IdAntecedeNosologico).HasColumnName("idAntecedeNosologico");
            entity.Property(e => e.Resultado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tratamiento1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Tratamiento");

            entity.HasOne(d => d.IdAntecedeNosologicoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdAntecedeNosologico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__idAnt__2FCF1A8A");
        });

        modelBuilder.Entity<TratamientoEfectuado>(entity =>
        {
            entity.HasKey(e => e.IdTratamientoEfectuado).HasName("PK__Tratamie__DAEB4BF6577133A9");

            entity.ToTable("TratamientoEfectuado");

            entity.Property(e => e.IdTratamientoEfectuado).HasColumnName("idTratamientoEfectuado");
            entity.Property(e => e.IdSesion).HasColumnName("idSesion");
            entity.Property(e => e.IdTiposEstructura).HasColumnName("idTiposEstructura");
            entity.Property(e => e.RespuestaAtecnica)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RespuestaATecnica");
            entity.Property(e => e.TecnicaUtilizada)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.TratamientoEfectuados)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__idSes__1332DBDC");

            entity.HasOne(d => d.IdTiposEstructuraNavigation).WithMany(p => p.TratamientoEfectuados)
                .HasForeignKey(d => d.IdTiposEstructura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__idTip__14270015");
        });

        modelBuilder.Entity<TroncoFlexion>(entity =>
        {
            entity.HasKey(e => e.IdTroncoFlexion).HasName("PK__TroncoFl__ACC31A2B9498753E");

            entity.ToTable("TroncoFlexion");

            entity.Property(e => e.IdTroncoFlexion).HasColumnName("idTroncoFlexion");
            entity.Property(e => e.Desempeno).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IdEvaluacionBiomecanica).HasColumnName("idEvaluacionBiomecanica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Puntuacion).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdEvaluacionBiomecanicaNavigation).WithMany(p => p.TroncoFlexions)
                .HasForeignKey(d => d.IdEvaluacionBiomecanica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TroncoFle__idEva__681373AD");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__Turnos__C1ECF79A43881D89");

            entity.Property(e => e.DiaSemana)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstadoTurno)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Turnos__IdPacien__7755B73D");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__Ubicacio__174D150E249A3E1F");

            entity.ToTable("Ubicacion");

            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Domicilio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF977EC7E11A");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
