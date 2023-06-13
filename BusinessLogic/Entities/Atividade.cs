using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Atividade
{
    public int IdAtividade { get; set; }

    public string? Nome { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Descricao { get; set; }

    public int? IdEvento { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual ICollection<InscricaoAtividade> InscricaoAtividades { get; set; } = new List<InscricaoAtividade>();
}
