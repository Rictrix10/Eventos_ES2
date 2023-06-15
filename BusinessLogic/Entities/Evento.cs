using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Evento
{
    public int IdEvento { get; set; }

    public string? Nome { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Local { get; set; }

    public string? Descricao { get; set; }

    public int? Capacidademax { get; set; }

    public string? Categoria { get; set; }

    public int? IdOrganizador { get; set; }

    public virtual ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();

    public virtual ICollection<EventoIngresso> EventoIngressos { get; set; } = new List<EventoIngresso>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Utilizador? IdOrganizadorNavigation { get; set; }

    public virtual ICollection<InscricaoEvento> InscricaoEventos { get; set; } = new List<InscricaoEvento>();

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();
}
