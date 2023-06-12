using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Mensagem
{
    public int Id { get; set; }

    public int? IdOrganizador { get; set; }

    public int? IdEvento { get; set; }

    public string? Assunto { get; set; }

    public string? Corpo { get; set; }

    public DateOnly? DataEnvio { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual Organizador? IdOrganizadorNavigation { get; set; }
}
