using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class InscricaoEvento
{
    public int IdInscricaoEvento { get; set; }

    public string? TipoIngresso { get; set; }
    
    public int? IdEvento { get; set; }

    public int? IdParticipante { get; set; }
    

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual Utilizador? IdParticipanteNavigation { get; set; }
}
