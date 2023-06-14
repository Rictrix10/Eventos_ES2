using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Feedback
{
    public int IdFeedback { get; set; }

    public string? Feedback1 { get; set; }

    public int? IdParticipante { get; set; }

    public int? IdEvento { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual Utilizador? IdParticipanteNavigation { get; set; }
}
