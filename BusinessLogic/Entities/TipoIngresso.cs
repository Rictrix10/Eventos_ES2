using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class TipoIngresso
{
    public int Id { get; set; }

    public int? IdEvento { get; set; }

    public string? Nome { get; set; }

    public int? QuantidadeDisponivel { get; set; }

    public decimal? Preco { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }
}
