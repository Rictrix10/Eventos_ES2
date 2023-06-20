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
            IdEvento = inscricaoevento.IdEvento;
            IdEventoNavigation = inscricaoevento.IdEventoNavigation?.Nome;
            IdParticipanteNavigation = inscricaoevento.IdParticipanteNavigation?.Nome;
            TipoIngresso = inscricaoevento.TipoIngresso;
            IdParticipante = inscricaoevento.IdParticipante;
            NomeOrganizador = inscricaoevento.IdEventoNavigation?.IdOrganizadorNavigation?.Nome;
            
            
        }
        

        public int IdInscricaoEvento { get; set; }
        
        public int? IdEvento { get; set; }

        public string? IdEventoNavigation { get; set; }
        public string? IdParticipanteNavigation { get; set; }
        
        public string TipoIngresso { get; set; }
        
        public int? IdParticipante { get; set; }
        
        public string? NomeOrganizador { get; set; }
        

        
        

        
        
    }
}