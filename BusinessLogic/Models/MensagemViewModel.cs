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
            IdMensagem = mensagem.IdMensagem;
            Mensagem1 = mensagem.Mensagem1;
            IdOrganizador = mensagem.IdOrganizador;
            IdParticipante = mensagem.IdParticipante;
            IdEvento = mensagem.IdEvento;
            IdEventoNavigation = mensagem.IdEventoNavigation?.Nome;
            IdOrganizadorNavigation = mensagem.IdOrganizadorNavigation?.Nome;
        }
        


        public int IdMensagem { get; set; }

        public string? Mensagem1 { get; set; }
        
        public int? IdOrganizador { get; set; }
        
        public int? IdParticipante { get; set; }
        
        public int? IdEvento { get; set; }
        
        public string? IdEventoNavigation { get; set; }
        
        public string? IdOrganizadorNavigation { get; set; }


    }
}