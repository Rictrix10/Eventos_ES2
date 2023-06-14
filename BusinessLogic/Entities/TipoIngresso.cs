using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class TipoIngresso
{
    public int IdTipoIngresso { get; set; }

    public string? Nome { get; set; }

    public decimal? Preco { get; set; }

    public virtual ICollection<EventoIngresso> EventoIngressos { get; set; } = new List<EventoIngresso>();
}
