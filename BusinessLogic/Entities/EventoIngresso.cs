using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class EventoIngresso
{
    public int IdIngresso { get; set; }

    public int? IdEvento { get; set; }

    public int? Quantidade { get; set; }

    public decimal? Preco { get; set; }

    public string? TipoIngresso { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }
}
