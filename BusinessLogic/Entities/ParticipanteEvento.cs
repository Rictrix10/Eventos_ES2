using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class ParticipanteEvento
{
    public int IdParticipante { get; set; }

    public int IdEvento { get; set; }

    public DateOnly? DataRegistro { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual Participante IdParticipanteNavigation { get; set; } = null!;
}
