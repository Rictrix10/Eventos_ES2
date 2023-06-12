using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Participante
{
    public int IdUtilizador { get; set; }

    public virtual Utilizador IdUtilizadorNavigation { get; set; } = null!;

    public virtual ICollection<ParticipanteEvento> ParticipanteEventos { get; set; } = new List<ParticipanteEvento>();

    public virtual ICollection<Atividade> IdAtividades { get; set; } = new List<Atividade>();
}
