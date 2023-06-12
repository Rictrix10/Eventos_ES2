using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Utilizador
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdTipo { get; set; }

    public virtual TipoUtilizador? IdTipoNavigation { get; set; }

    public virtual Organizador? Organizador { get; set; }

    public virtual Participante? Participante { get; set; }
}
