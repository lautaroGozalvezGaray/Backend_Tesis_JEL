using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_OsteoHealth_Tesis.Models;

public partial class OsteoHealthContext : DbContext
{
    public OsteoHealthContext(DbContextOptions<OsteoHealthContext> options)
        : base(options)
    {
    }

    // En OsteoHealthContext.cs
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Cualquier DateTimeOffset se mapea a timestamptz
        configurationBuilder.Properties<DateTimeOffset>()
            .HaveColumnType("timestamp with time zone");
    }


    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<actividad_fisica> actividad_fisicas { get; set; }

    public virtual DbSet<actividad_laboral_profesional> actividad_laboral_profesionals { get; set; }

    public virtual DbSet<alimentacion> alimentacions { get; set; }

    public virtual DbSet<antecedentes_tocoginecologicos> antecedentes_tocoginecologicos { get; set; }

    public virtual DbSet<calidad_percibida_sueno> calidad_percibida_suenos { get; set; }

    public virtual DbSet<caracteristica> caracteristicas { get; set; }

    public virtual DbSet<clase_comida_predominante> clase_comida_predominantes { get; set; }

    public virtual DbSet<comida_predominante> comida_predominantes { get; set; }

    public virtual DbSet<desplante_linea> desplante_lineas { get; set; }

    public virtual DbSet<digestion> digestions { get; set; }

    public virtual DbSet<escucha_osteopatica> escucha_osteopaticas { get; set; }

    public virtual DbSet<estabilidad_rotacion> estabilidad_rotacions { get; set; }

    public virtual DbSet<estado_digestion> estado_digestions { get; set; }

    public virtual DbSet<estilo_actividad_laboral> estilo_actividad_laborals { get; set; }

    public virtual DbSet<estudio> estudios { get; set; }

    public virtual DbSet<estudios_nosocologico> estudios_nosocologicos { get; set; }

    public virtual DbSet<evaluacion_biomecanica> evaluacion_biomecanicas { get; set; }

    public virtual DbSet<forma_ingestum> forma_ingesta { get; set; }

    public virtual DbSet<frecuencia_lapso> frecuencia_lapsos { get; set; }

    public virtual DbSet<habitos_toxico> habitos_toxicos { get; set; }

    public virtual DbSet<imagen_paciente> imagen_pacientes { get; set; }

    public virtual DbSet<informacion_adicional> informacion_adicionals { get; set; }

    public virtual DbSet<informe_medico> informe_medicos { get; set; }

    public virtual DbSet<levantamiento_pierna> levantamiento_piernas { get; set; }

    public virtual DbSet<metodo_anticonceptivo> metodo_anticonceptivos { get; set; }

    public virtual DbSet<movilidad_hombro> movilidad_hombros { get; set; }

    public virtual DbSet<obra_social> obra_socials { get; set; }

    public virtual DbSet<paciente> pacientes { get; set; }

    public virtual DbSet<parentezco> parentezcos { get; set; }

    public virtual DbSet<paso_obstaculo> paso_obstaculos { get; set; }

    public virtual DbSet<sentadilla> sentadillas { get; set; }

    public virtual DbSet<sesion> sesions { get; set; }

    public DbSet<SesionDraft> SesionDrafts { get; set; }

    public DbSet<SesionRaw> SesionesRaw { get; set; }

    public virtual DbSet<sexo> sexos { get; set; }

    public virtual DbSet<sindrome_detectado> sindrome_detectados { get; set; }

    public virtual DbSet<sintoma_clinico> sintoma_clinicos { get; set; }

    public virtual DbSet<sintoma_digestion> sintoma_digestions { get; set; }

    public virtual DbSet<sintomatologium> sintomatologia { get; set; }

    public virtual DbSet<sueno> suenos { get; set; }

    public virtual DbSet<tipo_actividad_fisica> tipo_actividad_fisicas { get; set; }

    public virtual DbSet<tipo_actividad_laboral> tipo_actividad_laborals { get; set; }

    public virtual DbSet<tipo_enfermedad> tipo_enfermedads { get; set; }

    public virtual DbSet<tipo_enfermedad_hereditaria> tipo_enfermedad_hereditaria { get; set; }

    public virtual DbSet<tipo_estudio> tipo_estudios { get; set; }

    public virtual DbSet<tipo_habito_toxico> tipo_habito_toxicos { get; set; }

    public virtual DbSet<tipos_estructura> tipos_estructuras { get; set; }

    public virtual DbSet<tratamiento> tratamientos { get; set; }

    public virtual DbSet<tratamiento_efectuado> tratamiento_efectuados { get; set; }

    public virtual DbSet<turno> turnos { get; set; }

    public virtual DbSet<ubicacion> ubicacions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("users_pkey");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
        });

        modelBuilder.Entity<actividad_fisica>(entity =>
        {
            entity.HasKey(e => e.idactividadfisica).HasName("actividad_fisica_pkey");

            entity.HasOne(d => d.idfrecuencialapsoNavigation).WithMany(p => p.actividad_fisicas).HasConstraintName("actividad_fisica_idfrecuencialapso_fkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.actividad_fisicas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actividad_fisica_idsesion_fkey");

            entity.HasOne(d => d.idtipoactividadfisicaNavigation).WithMany(p => p.actividad_fisicas).HasConstraintName("actividad_fisica_idtipoactividadfisica_fkey");
        });

        modelBuilder.Entity<actividad_laboral_profesional>(entity =>
        {
            entity.HasKey(e => e.idactividadlaboralprofesional).HasName("actividad_laboral_profesional_pkey");

            entity.HasOne(d => d.idestiloactividadlaboralNavigation).WithMany(p => p.actividad_laboral_profesionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actividad_laboral_profesional_idestiloactividadlaboral_fkey");

            entity.HasOne(d => d.idfrecuencialapsoNavigation).WithMany(p => p.actividad_laboral_profesionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actividad_laboral_profesional_idfrecuencialapso_fkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.actividad_laboral_profesionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actividad_laboral_profesional_idsesion_fkey");

            entity.HasOne(d => d.idtipoactividadlaboralNavigation).WithMany(p => p.actividad_laboral_profesionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("actividad_laboral_profesional_idtipoactividadlaboral_fkey");
        });

        modelBuilder.Entity<alimentacion>(entity =>
        {
            entity.HasKey(e => e.idalimentacion).HasName("alimentacion_pkey");

            entity.HasOne(d => d.idclasecomidapredominanteNavigation).WithMany(p => p.alimentacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alimentacion_idclasecomidapredominante_fkey");

            entity.HasOne(d => d.idcomidapredominanteNavigation).WithMany(p => p.alimentacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alimentacion_idcomidapredominante_fkey");

            entity.HasOne(d => d.idformaingestaNavigation).WithMany(p => p.alimentacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alimentacion_idformaingesta_fkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.alimentacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alimentacion_idsesion_fkey");
        });

        modelBuilder.Entity<antecedentes_tocoginecologicos>(entity =>
        {
            entity.HasKey(e => e.idantecedetoco).HasName("antecedentes_tocoginecologicos_pkey");

            entity.HasOne(d => d.dniNavigation).WithMany(p => p.antecedentes_tocoginecologicos).HasConstraintName("antecedentes_tocoginecologicos_dni_fkey");

            entity.HasOne(d => d.idmetodoNavigation).WithMany(p => p.antecedentes_tocoginecologicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("antecedentes_tocoginecologicos_idmetodo_fkey");
        });

        modelBuilder.Entity<calidad_percibida_sueno>(entity =>
        {
            entity.HasKey(e => e.idcalidadpercibidasueno).HasName("calidad_percibida_sueno_pkey");
        });

        modelBuilder.Entity<caracteristica>(entity =>
        {
            entity.HasKey(e => e.idcaracteristicas).HasName("caracteristicas_pkey");
        });

        modelBuilder.Entity<clase_comida_predominante>(entity =>
        {
            entity.HasKey(e => e.idclasecomidapredominante).HasName("clase_comida_predominante_pkey");
        });

        modelBuilder.Entity<comida_predominante>(entity =>
        {
            entity.HasKey(e => e.idcomidapredominante).HasName("comida_predominante_pkey");
        });

        modelBuilder.Entity<desplante_linea>(entity =>
        {
            entity.HasKey(e => e.iddesplantelinea).HasName("desplante_linea_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.desplante_lineas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("desplante_linea_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<digestion>(entity =>
        {
            entity.HasKey(e => e.iddigestion).HasName("digestion_pkey");

            entity.HasOne(d => d.idestadodigestionNavigation).WithMany(p => p.digestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("digestion_idestadodigestion_fkey");

            entity.HasOne(d => d.idfrecuencialapsoNavigation).WithMany(p => p.digestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("digestion_idfrecuencialapso_fkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.digestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("digestion_idsesion_fkey");

            entity.HasOne(d => d.idsintomadigestionNavigation).WithMany(p => p.digestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("digestion_idsintomadigestion_fkey");
        });

        modelBuilder.Entity<escucha_osteopatica>(entity =>
        {
            entity.HasKey(e => e.idescuchaosteopatica).HasName("escucha_osteopatica_pkey");

            entity.HasOne(d => d.idsindromedetectadoNavigation).WithMany(p => p.escucha_osteopaticas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("escucha_osteopatica_idsindromedetectado_fkey");

            entity.HasOne(d => d.idtiposestructuraNavigation).WithMany(p => p.escucha_osteopaticas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("escucha_osteopatica_idtiposestructura_fkey");
        });

        modelBuilder.Entity<estabilidad_rotacion>(entity =>
        {
            entity.HasKey(e => e.idestabilidadrotacion).HasName("estabilidad_rotacion_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.estabilidad_rotacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estabilidad_rotacion_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<estado_digestion>(entity =>
        {
            entity.HasKey(e => e.idestadodigestion).HasName("estado_digestion_pkey");
        });

        modelBuilder.Entity<estilo_actividad_laboral>(entity =>
        {
            entity.HasKey(e => e.idestiloactividadlaboral).HasName("estilo_actividad_laboral_pkey");
        });

        modelBuilder.Entity<estudio>(entity =>
        {
            entity.HasKey(e => e.idestudios).HasName("estudios_pkey");

            entity.HasOne(d => d.idantecedenosologicoNavigation).WithMany(p => p.estudios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudios_idantecedenosologico_fkey");
        });

        modelBuilder.Entity<estudios_nosocologico>(entity =>
        {
            entity.HasKey(e => e.idantecedenosologico).HasName("estudios_nosocologicos_pkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.estudios_nosocologicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudios_nosocologicos_idsesion_fkey");
        });

        modelBuilder.Entity<evaluacion_biomecanica>(entity =>
        {
            entity.HasKey(e => e.idevaluacionbiomecanica).HasName("evaluacion_biomecanica_pkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.evaluacion_biomecanicas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evaluacion_biomecanica_idsesion_fkey");
        });

        modelBuilder.Entity<forma_ingestum>(entity =>
        {
            entity.HasKey(e => e.idformaingesta).HasName("forma_ingesta_pkey");
        });

        modelBuilder.Entity<frecuencia_lapso>(entity =>
        {
            entity.HasKey(e => e.idfrecuencialapso).HasName("frecuencia_lapso_pkey");
        });

        modelBuilder.Entity<habitos_toxico>(entity =>
        {
            entity.HasKey(e => e.idhabitostoxicos).HasName("habitos_toxicos_pkey");

            entity.HasOne(d => d.idfrecuencialapsoNavigation).WithMany(p => p.habitos_toxicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("habitos_toxicos_idfrecuencialapso_fkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.habitos_toxicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("habitos_toxicos_idsesion_fkey");

            entity.HasOne(d => d.idsintomatologiaNavigation).WithMany(p => p.habitos_toxicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("habitos_toxicos_idsintomatologia_fkey");

            entity.HasOne(d => d.idtipohabitotoxicoNavigation).WithMany(p => p.habitos_toxicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("habitos_toxicos_idtipohabitotoxico_fkey");
        });

        modelBuilder.Entity<imagen_paciente>(entity =>
        {
            entity.HasKey(e => e.idimagen).HasName("imagen_paciente_pkey");
        });

        modelBuilder.Entity<informacion_adicional>(entity =>
        {
            entity.HasKey(e => e.idinformacionadicional).HasName("informacion_adicional_pkey");
        });

        modelBuilder.Entity<informe_medico>(entity =>
        {
            entity.HasKey(e => e.idinformemedico).HasName("informe_medico_pkey");

            entity.HasOne(d => d.idantecedenosologicoNavigation).WithMany(p => p.informe_medicos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("informe_medico_idantecedenosologico_fkey");
        });

        modelBuilder.Entity<levantamiento_pierna>(entity =>
        {
            entity.HasKey(e => e.idlevantamientopierna).HasName("levantamiento_pierna_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.levantamiento_piernas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("levantamiento_pierna_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<metodo_anticonceptivo>(entity =>
        {
            entity.HasKey(e => e.idmetodo).HasName("metodo_anticonceptivo_pkey");
        });

        modelBuilder.Entity<movilidad_hombro>(entity =>
        {
            entity.HasKey(e => e.idmovilidadhombros).HasName("movilidad_hombros_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.movilidad_hombros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movilidad_hombros_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<obra_social>(entity =>
        {
            entity.HasKey(e => e.idobrasocial).HasName("obra_social_pkey");
        });

        modelBuilder.Entity<paciente>(entity =>
        {
            entity.HasKey(e => e.dni).HasName("paciente_pkey");

            entity.HasOne(d => d.idimagenNavigation).WithMany(p => p.pacientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_idimagen_fkey");

            entity.HasOne(d => d.idinformacionadicionalNavigation).WithMany(p => p.pacientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_idinformacionadicional_fkey");

            entity.HasOne(d => d.idobrasocialNavigation).WithMany(p => p.pacientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_idobrasocial_fkey");

            entity.HasOne(d => d.idubicacionNavigation).WithMany(p => p.pacientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paciente_idubicacion_fkey");

            entity.HasOne(d => d.sexoNavigation).WithMany(p => p.pacientes).HasConstraintName("paciente_sexo_fkey");
        });

        modelBuilder.Entity<parentezco>(entity =>
        {
            entity.HasKey(e => e.idparentezco).HasName("parentezco_pkey");
        });

        modelBuilder.Entity<paso_obstaculo>(entity =>
        {
            entity.HasKey(e => e.idpasoobstaculo).HasName("paso_obstaculo_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.paso_obstaculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paso_obstaculo_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<sentadilla>(entity =>
        {
            entity.HasKey(e => e.idsentadilla).HasName("sentadilla_pkey");

            entity.HasOne(d => d.idevaluacionbiomecanicaNavigation).WithMany(p => p.sentadillas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sentadilla_idevaluacionbiomecanica_fkey");
        });

        modelBuilder.Entity<sesion>(entity =>
        {
            entity.HasKey(e => e.idsesion).HasName("sesion_pkey");

            entity.HasOne(d => d.dniNavigation).WithMany(p => p.sesions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sesion_dni_fkey");

            entity.HasOne(d => d.idcaracteristicasNavigation).WithMany(p => p.sesions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sesion_idcaracteristicas_fkey");

            entity.HasOne(d => d.idestadodigestionNavigation).WithMany(p => p.sesions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sesion_idestadodigestion_fkey");

            entity.HasOne(d => d.idsintomaclinicoNavigation).WithMany(p => p.sesions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sesion_idsintomaclinico_fkey");

            entity.HasOne(d => d.idsuenoNavigation).WithMany(p => p.sesions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sesion_idsueno_fkey");
        });

        modelBuilder.Entity<SesionDraft>(e =>
        {
            e.ToTable("sesion_drafts");

            // Clave primaria (ya tenés [Key], pero lo dejo explícito)
            e.HasKey(x => x.id);

            // Mapeo columnas
            e.Property(x => x.id).HasColumnName("id");
            e.Property(x => x.SesionId).HasColumnName("sesionid");
            e.Property(x => x.Step).HasColumnName("step");
            e.Property(x => x.DataJson)
                .HasColumnName("datajson")
                .HasColumnType("text"); // si algún día migrás a jsonb, cambiá a "jsonb"
            e.Property(x => x.UpdatedAt)
                .HasColumnName("updatedat")
                .HasColumnType("timestamp with time zone");

            // ÍNDICE ÚNICO compuesto: un solo draft por (SesionId, Step)
            e.HasIndex(x => new { x.SesionId, x.Step })
             .IsUnique()
             .HasDatabaseName("ix_sesion_drafts_sesionid_step");

            // (Opcional) índices auxiliares útiles para queries
            e.HasIndex(x => x.SesionId).HasDatabaseName("ix_sesion_drafts_sesionid");
            e.HasIndex(x => x.UpdatedAt).HasDatabaseName("ix_sesion_drafts_updatedat");

            // (Opcional) clave alterna si después querés usar (SesionId, Step) como principal en relaciones
            // e.HasAlternateKey(x => new { x.SesionId, x.Step })
            //  .HasName("ak_sesion_drafts_sesionid_step");
        });



        // SesionRaw probablemente quedó con columnas PascalCase ("Id","CreatedAt"...),
        // así que no mapees aquí a minúsculas. Solo fija el tipo del JSON si querés:
        modelBuilder.Entity<SesionRaw>(entity =>
        {
            entity.ToTable("sesiones_raw");
            entity.HasKey(e => e.id);
            entity.Property(x => x.payloadjson)
            .HasColumnType("jsonb"); // obliga a EF/Npgsql a tratarlo como JSONB
            // No toques CreatedAt/Id si ya existen como "CreatedAt"/"Id" en la DB
        });

        modelBuilder.Entity<sexo>(entity =>
        {
            entity.HasKey(e => e.idsexo).HasName("sexo_pkey");
        });

        modelBuilder.Entity<sindrome_detectado>(entity =>
        {
            entity.HasKey(e => e.idsindromedetectado).HasName("sindrome_detectado_pkey");
        });

        modelBuilder.Entity<sintoma_clinico>(entity =>
        {
            entity.HasKey(e => e.idsintomaclinico).HasName("sintoma_clinico_pkey");
        });

        modelBuilder.Entity<sintoma_digestion>(entity =>
        {
            entity.HasKey(e => e.idsintomadigestion).HasName("sintoma_digestion_pkey");
        });

        modelBuilder.Entity<sintomatologium>(entity =>
        {
            entity.HasKey(e => e.idsintomatologia).HasName("sintomatologia_pkey");
        });

        modelBuilder.Entity<sueno>(entity =>
        {
            entity.HasKey(e => e.idsueno).HasName("sueno_pkey");

            entity.HasOne(d => d.idcalidadpercibidasuenoNavigation).WithMany(p => p.suenos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sueno_idcalidadpercibidasueno_fkey");
        });

        modelBuilder.Entity<tipo_actividad_fisica>(entity =>
        {
            entity.HasKey(e => e.idtipoactividadfisica).HasName("tipo_actividad_fisica_pkey");
        });

        modelBuilder.Entity<tipo_actividad_laboral>(entity =>
        {
            entity.HasKey(e => e.idtipoactividadlaboral).HasName("tipo_actividad_laboral_pkey");
        });

        modelBuilder.Entity<tipo_enfermedad>(entity =>
        {
            entity.HasKey(e => e.idenfermedad).HasName("tipo_enfermedad_pkey");
        });

        modelBuilder.Entity<tipo_enfermedad_hereditaria>(entity =>
        {
            entity.HasKey(e => e.idenfermedadhereditaria).HasName("tipo_enfermedad_hereditaria_pkey");

            entity.HasOne(d => d.dniNavigation).WithMany(p => p.tipo_enfermedad_hereditaria).HasConstraintName("tipo_enfermedad_hereditaria_dni_fkey");

            entity.HasOne(d => d.idenfermedadNavigation).WithMany(p => p.tipo_enfermedad_hereditaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_enfermedad_hereditaria_idenfermedad_fkey");

            entity.HasOne(d => d.idparentezcoNavigation).WithMany(p => p.tipo_enfermedad_hereditaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_enfermedad_hereditaria_idparentezco_fkey");
        });

        modelBuilder.Entity<tipo_estudio>(entity =>
        {
            entity.HasKey(e => e.idtipoestudios).HasName("tipo_estudios_pkey");

            entity.HasOne(d => d.idantecedenosologicoNavigation).WithMany(p => p.tipo_estudios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_estudios_idantecedenosologico_fkey");
        });

        modelBuilder.Entity<tipo_habito_toxico>(entity =>
        {
            entity.HasKey(e => e.idtipohabitotoxico).HasName("tipo_habito_toxico_pkey");
        });

        modelBuilder.Entity<tipos_estructura>(entity =>
        {
            entity.HasKey(e => e.idtiposestructura).HasName("tipos_estructura_pkey");
        });

        modelBuilder.Entity<tratamiento>(entity =>
        {
            entity.HasKey(e => e.idtratamiento).HasName("tratamientos_pkey");

            entity.HasOne(d => d.idantecedenosologicoNavigation).WithMany(p => p.tratamientos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tratamientos_idantecedenosologico_fkey");
        });

        modelBuilder.Entity<tratamiento_efectuado>(entity =>
        {
            entity.HasKey(e => e.idtratamientoefectuado).HasName("tratamiento_efectuado_pkey");

            entity.HasOne(d => d.idsesionNavigation).WithMany(p => p.tratamiento_efectuados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tratamiento_efectuado_idsesion_fkey");

            entity.HasOne(d => d.idtiposestructuraNavigation).WithMany(p => p.tratamiento_efectuados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tratamiento_efectuado_idtiposestructura_fkey");
        });

        modelBuilder.Entity<turno>(entity =>
        {
            entity.HasKey(e => e.dturno).HasName("turno_pkey");

            entity.Property(e => e.dturno).UseIdentityAlwaysColumn();
            entity.Property(e => e.duracionminutos).HasDefaultValue(30);
            entity.Property(e => e.idpaciente).ValueGeneratedOnAdd();

            entity.HasOne(d => d.idpacienteNavigation).WithMany(p => p.turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_turno_paciente");

            entity.HasOne(d => d.idusuarioNavigation).WithMany(p => p.turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_turno_usuario");
        });

        modelBuilder.Entity<ubicacion>(entity =>
        {
            entity.HasKey(e => e.idubicacion).HasName("ubicacion_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
