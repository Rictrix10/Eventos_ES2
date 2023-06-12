using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Atividade
{
    public int Id { get; set; }

    public int? IdEvento { get; set; }

    public string? Nome { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Descricao { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual ICollection<Participante> IdParticipantes { get; set; } = new List<Participante>();
}
