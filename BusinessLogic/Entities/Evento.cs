using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Evento
{
    public int Id { get; set; }

    public int? IdOrganizador { get; set; }

    public string? Nome { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Local { get; set; }

    public string? Descricao { get; set; }

    public int? CapacidadeMax { get; set; }

    public decimal? PrecoIngresso { get; set; }

    public virtual ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();

    public virtual Organizador? IdOrganizadorNavigation { get; set; }

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();

    public virtual ICollection<ParticipanteEvento> ParticipanteEventos { get; set; } = new List<ParticipanteEvento>();

    public virtual ICollection<TipoIngresso> TipoIngressos { get; set; } = new List<TipoIngresso>();
}
