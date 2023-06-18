using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class MensagemViewModel
    {
        public MensagemViewModel()
        {

        }

        public MensagemViewModel(Mensagem mensagem)
        {
            Mensagem1 = mensagem.Mensagem1;
            IdMensagem = mensagem.IdMensagem;
            IdEvento = mensagem.IdEvento;
            IdEventoNavigation = mensagem.IdEventoNavigation;
            IdOrganizador = mensagem.IdOrganizador;
            IdParticipante = mensagem.IdParticipante;
            IdOrganizadorNavigation = mensagem.IdOrganizadorNavigation;
            IdParticipanteNavigation = mensagem.IdParticipanteNavigation;
            
        }

        public Utilizador IdParticipanteNavigation { get; set; }

        public Utilizador IdOrganizadorNavigation { get; set; }

        public int? IdParticipante { get; set; }

        public int? IdOrganizador { get; set; }

        public Evento IdEventoNavigation { get; set; }

        public int? IdEvento { get; set; }

        public int IdMensagem { get; set; }

        public string? Mensagem1 { get; set; }
    }
}