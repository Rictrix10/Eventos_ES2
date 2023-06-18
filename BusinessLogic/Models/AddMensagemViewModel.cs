using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class AddMensagemViewModel
    {
        public AddMensagemViewModel()
        {

        }

        public AddMensagemViewModel(Mensagem mensagem)
        {   
            IdMensagem = mensagem.IdMensagem;
            Mensagem1 = mensagem.Mensagem1;
            IdOrganizador = mensagem.IdOrganizador;
            IdParticipante = mensagem.IdParticipante;
            IdEvento = mensagem.IdEvento;
            
        }
        
        public int IdMensagem { get; set; }

        public string? Mensagem1 { get; set; }
        
        public int? IdOrganizador { get; set; }
        
        public int? IdParticipante { get; set; }
        
        public int? IdEvento { get; set; }


    }
}