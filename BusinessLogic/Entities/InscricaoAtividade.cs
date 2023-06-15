using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class InscricaoAtividade
{
    public int IdInscricaoAtividade { get; set; }

    public int? IdParticipante { get; set; }

    public int? IdAtividade { get; set; }

    public virtual Atividade? IdAtividadeNavigation { get; set; }

    public virtual Utilizador? IdParticipanteNavigation { get; set; }
}
