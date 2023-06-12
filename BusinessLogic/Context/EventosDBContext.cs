using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Context;

public partial class EventosDBContext : DbContext
{
    public EventosDBContext()
    {
    }

    public EventosDBContext(DbContextOptions<EventosDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atividade> Atividades { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

    public virtual DbSet<Organizador> Organizadors { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<ParticipanteEvento> ParticipanteEventos { get; set; }

    public virtual DbSet<TipoIngresso> TipoIngressos { get; set; }

    public virtual DbSet<TipoUtilizador> TipoUtilizadors { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("topology", "postgis_topology");

        modelBuilder.Entity<Atividade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("atividade_pkey");

            entity.ToTable("atividade");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Atividades)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("atividade_id_evento_fkey");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evento_pkey");

            entity.ToTable("evento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CapacidadeMax).HasColumnName("capacidade_max");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.Local)
                .HasMaxLength(50)
                .HasColumnName("local");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.PrecoIngresso)
                .HasPrecision(10, 2)
                .HasColumnName("preco_ingresso");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdOrganizador)
                .HasConstraintName("evento_id_organizador_fkey");
        });

        modelBuilder.Entity<Mensagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mensagem_pkey");

            entity.ToTable("mensagem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assunto)
                .HasMaxLength(50)
                .HasColumnName("assunto");
            entity.Property(e => e.Corpo).HasColumnName("corpo");
            entity.Property(e => e.DataEnvio).HasColumnName("data_envio");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("mensagem_id_evento_fkey");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdOrganizador)
                .HasConstraintName("mensagem_id_organizador_fkey");
        });

        modelBuilder.Entity<Organizador>(entity =>
        {
            entity.HasKey(e => e.IdUtilizador).HasName("organizador_pkey");

            entity.ToTable("organizador");

            entity.Property(e => e.IdUtilizador)
                .ValueGeneratedNever()
                .HasColumnName("id_utilizador");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithOne(p => p.Organizador)
                .HasForeignKey<Organizador>(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizador_id_utilizador_fkey");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdUtilizador).HasName("participante_pkey");

            entity.ToTable("participante");

            entity.Property(e => e.IdUtilizador)
                .ValueGeneratedNever()
                .HasColumnName("id_utilizador");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithOne(p => p.Participante)
                .HasForeignKey<Participante>(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("participante_id_utilizador_fkey");

            entity.HasMany(d => d.IdAtividades).WithMany(p => p.IdParticipantes)
                .UsingEntity<Dictionary<string, object>>(
                    "ParticipanteAtividade",
                    r => r.HasOne<Atividade>().WithMany()
                        .HasForeignKey("IdAtividade")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("participante_atividade_id_atividade_fkey"),
                    l => l.HasOne<Participante>().WithMany()
                        .HasForeignKey("IdParticipante")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("participante_atividade_id_participante_fkey"),
                    j =>
                    {
                        j.HasKey("IdParticipante", "IdAtividade").HasName("participante_atividade_pkey");
                        j.ToTable("participante_atividade");
                        j.IndexerProperty<int>("IdParticipante").HasColumnName("id_participante");
                        j.IndexerProperty<int>("IdAtividade").HasColumnName("id_atividade");
                    });
        });

        modelBuilder.Entity<ParticipanteEvento>(entity =>
        {
            entity.HasKey(e => new { e.IdParticipante, e.IdEvento }).HasName("participante_evento_pkey");

            entity.ToTable("participante_evento");

            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.ParticipanteEventos)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("participante_evento_id_evento_fkey");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.ParticipanteEventos)
                .HasForeignKey(d => d.IdParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("participante_evento_id_participante_fkey");
        });

        modelBuilder.Entity<TipoIngresso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_ingresso_pkey");

            entity.ToTable("tipo_ingresso");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");
            entity.Property(e => e.QuantidadeDisponivel).HasColumnName("quantidade_disponivel");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.TipoIngressos)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("tipo_ingresso_id_evento_fkey");
        });

        modelBuilder.Entity<TipoUtilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_utilizador_pkey");

            entity.ToTable("tipo_utilizador");

            entity.HasIndex(e => e.Tipo, "tipo_utilizador_tipo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("utilizador_pkey");

            entity.ToTable("utilizador");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("utilizador_id_tipo_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
