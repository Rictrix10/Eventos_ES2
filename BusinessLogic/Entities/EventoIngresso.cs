﻿using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class EventoIngresso
{
    public int IdEvento { get; set; }

    public int IdIngresso { get; set; }

    public int? Quantidade { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual TipoIngresso IdIngressoNavigation { get; set; } = null!;
}
