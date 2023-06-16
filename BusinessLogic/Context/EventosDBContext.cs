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

    public virtual DbSet<Autenticacao> Autenticacaos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventoIngresso> EventoIngressos { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<InscricaoAtividade> InscricaoAtividades { get; set; }

    public virtual DbSet<InscricaoEvento> InscricaoEventos { get; set; }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

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
            entity.HasKey(e => e.IdAtividade).HasName("atividade_pkey");

            entity.ToTable("atividade");

            entity.Property(e => e.IdAtividade).HasColumnName("id_atividade");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Atividades)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("atividade_id_evento_fkey");
        });

        modelBuilder.Entity<Autenticacao>(entity =>
        {
            entity.HasKey(e => e.IdAutenticacao).HasName("autenticacao_pkey");

            entity.ToTable("autenticacao");

            entity.Property(e => e.IdAutenticacao).HasColumnName("id_autenticacao");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("evento_pkey");

            entity.ToTable("evento");

            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.Capacidademax).HasColumnName("capacidademax");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("categoria");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.Local)
                .HasMaxLength(255)
                .HasColumnName("local");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdOrganizador)
                .HasConstraintName("evento_id_organizador_fkey");
        });

        modelBuilder.Entity<EventoIngresso>(entity =>
        {
            entity.HasKey(e => new { e.IdEvento, e.IdIngresso }).HasName("evento_ingresso_pkey");

            entity.ToTable("evento_ingresso");

            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdIngresso).HasColumnName("id_ingresso");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");
            entity.Property(e => e.TipoIngresso)
                .HasMaxLength(255)
                .HasColumnName("tipo_ingresso");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.EventoIngressos)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evento_ingresso_id_evento_fkey");

            entity.HasOne(d => d.IdIngressoNavigation).WithMany(p => p.EventoIngressos)
                .HasForeignKey(d => d.IdIngresso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evento_ingresso_id_ingresso_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.IdFeedback).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.IdFeedback).HasColumnName("id_feedback");
            entity.Property(e => e.Feedback1).HasColumnName("feedback");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("feedback_id_evento_fkey");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("feedback_id_participante_fkey");
        });

        modelBuilder.Entity<InscricaoAtividade>(entity =>
        {
            entity.HasKey(e => e.IdInscricaoAtividade).HasName("inscricao_atividade_pkey");

            entity.ToTable("inscricao_atividade");

            entity.Property(e => e.IdInscricaoAtividade).HasColumnName("id_inscricao_atividade");
            entity.Property(e => e.IdAtividade).HasColumnName("id_atividade");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");

            entity.HasOne(d => d.IdAtividadeNavigation).WithMany(p => p.InscricaoAtividades)
                .HasForeignKey(d => d.IdAtividade)
                .HasConstraintName("inscricao_atividade_id_atividade_fkey");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.InscricaoAtividades)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("inscricao_atividade_id_participante_fkey");
        });

        modelBuilder.Entity<InscricaoEvento>(entity =>
        {
            entity.HasKey(e => e.IdInscricaoEvento).HasName("inscricao_evento_pkey");

            entity.ToTable("inscricao_evento");

            entity.Property(e => e.IdInscricaoEvento).HasColumnName("id_inscricao_evento");
            entity.Property(e => e.TipoIngresso)
                .HasMaxLength(255)
                .HasColumnName("tipo_ingresso");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.InscricaoEventos)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("inscricao_evento_id_evento_fkey");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.InscricaoEventos)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("inscricao_evento_id_participante_fkey");
        });

        modelBuilder.Entity<Mensagem>(entity =>
        {
            entity.HasKey(e => e.IdMensagem).HasName("mensagem_pkey");

            entity.ToTable("mensagem");

            entity.Property(e => e.IdMensagem).HasColumnName("id_mensagem");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");
            entity.Property(e => e.Mensagem1).HasColumnName("mensagem");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("mensagem_id_evento_fkey");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.MensagemIdOrganizadorNavigations)
                .HasForeignKey(d => d.IdOrganizador)
                .HasConstraintName("mensagem_id_organizador_fkey");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.MensagemIdParticipanteNavigations)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("mensagem_id_participante_fkey");
        });

        modelBuilder.Entity<TipoIngresso>(entity =>
        {
            entity.HasKey(e => e.IdTipoIngresso).HasName("tipo_ingresso_pkey");

            entity.ToTable("tipo_ingresso");

            entity.Property(e => e.IdTipoIngresso).HasColumnName("id_tipo_ingresso");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");
        });

        modelBuilder.Entity<TipoUtilizador>(entity =>
        {
            entity.HasKey(e => e.IdTipoUtilizador).HasName("tipo_utilizador_pkey");

            entity.ToTable("tipo_utilizador");

            entity.Property(e => e.IdTipoUtilizador).HasColumnName("id_tipo_utilizador");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.IdUtilizador).HasName("utilizador_pkey");

            entity.ToTable("utilizador");

            entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IdAutenticacao).HasColumnName("id_autenticacao");
            entity.Property(e => e.IdTipoUtilizador).HasColumnName("id_tipo_utilizador");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Telefone)
                .HasMaxLength(255)
                .HasColumnName("telefone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
            entity.Property(e => e.Autenticacao)
                .HasMaxLength(255)
                .HasColumnName("autenticacao");
                

            entity.HasOne(d => d.IdAutenticacaoNavigation).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.IdAutenticacao)
                .HasConstraintName("utilizador_id_autenticacao_fkey");

            entity.HasOne(d => d.IdTipoUtilizadorNavigation).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.IdTipoUtilizador)
                .HasConstraintName("utilizador_id_tipo_utilizador_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
