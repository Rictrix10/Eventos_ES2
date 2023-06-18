using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class AutenticacaoViewModel
    {
        public AutenticacaoViewModel()
        {

        }

        public AutenticacaoViewModel(Autenticacao autenticacao)
        {
            IdAutenticacao = autenticacao.IdAutenticacao;
            Tipo = autenticacao.Tipo;
            Utilizadors = autenticacao.Utilizadors;
        }

        public ICollection<Utilizador> Utilizadors { get; set; }

        public string? Tipo { get; set; }

        public int IdAutenticacao { get; set; }
    }
}

