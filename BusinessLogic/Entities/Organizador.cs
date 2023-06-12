using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Organizador
{
    public int IdUtilizador { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual Utilizador IdUtilizadorNavigation { get; set; } = null!;

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();
}
