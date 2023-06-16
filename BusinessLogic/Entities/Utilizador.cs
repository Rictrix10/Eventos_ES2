using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Utilizador
{
    public int IdUtilizador { get; set; }

    public string? Username { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Telefone { get; set; }
    
    public string? Tipo { get; set; }
    
    public string? Autenticacao { get; set; }

    public int? IdTipoUtilizador { get; set; }

    public int? IdAutenticacao { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Autenticacao? IdAutenticacaoNavigation { get; set; }

    public virtual TipoUtilizador? IdTipoUtilizadorNavigation { get; set; }

    public virtual ICollection<InscricaoAtividade> InscricaoAtividades { get; set; } = new List<InscricaoAtividade>();

    public virtual ICollection<InscricaoEvento> InscricaoEventos { get; set; } = new List<InscricaoEvento>();

    public virtual ICollection<Mensagem> MensagemIdOrganizadorNavigations { get; set; } = new List<Mensagem>();

    public virtual ICollection<Mensagem> MensagemIdParticipanteNavigations { get; set; } = new List<Mensagem>();
}
