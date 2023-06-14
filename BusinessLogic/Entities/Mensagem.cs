using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Mensagem
{
    public int IdMensagem { get; set; }

    public string? Mensagem1 { get; set; }

    public int? IdOrganizador { get; set; }

    public int? IdParticipante { get; set; }

    public int? IdEvento { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual Utilizador? IdOrganizadorNavigation { get; set; }

    public virtual Utilizador? IdParticipanteNavigation { get; set; }
}
