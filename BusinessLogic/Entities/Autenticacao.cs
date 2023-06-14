using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Autenticacao
{
    public int IdAutenticacao { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Utilizador> Utilizadors { get; set; } = new List<Utilizador>();
}
