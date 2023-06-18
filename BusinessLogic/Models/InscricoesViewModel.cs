using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class InscricoesViewModel
    {
        public InscricoesViewModel()
        {

        }

        public InscricoesViewModel(InscricaoEvento inscricaoevento)
        {   
            IdInscricaoEvento = inscricaoevento.IdInscricaoEvento;
            IdEventoNavigation = inscricaoevento.IdEventoNavigation?.Nome;
            IdParticipanteNavigation = inscricaoevento.IdParticipanteNavigation?.Nome;
            TipoIngresso = inscricaoevento.TipoIngresso;
            IdParticipante = inscricaoevento.IdParticipante;
            
            
        }

        public int IdInscricaoEvento { get; set; }

        public string? IdEventoNavigation { get; set; }
        public string? IdParticipanteNavigation { get; set; }
        
        public string TipoIngresso { get; set; }
        
        
        public int? IdParticipante { get; set; }
        

        
        

        
        
    }
}