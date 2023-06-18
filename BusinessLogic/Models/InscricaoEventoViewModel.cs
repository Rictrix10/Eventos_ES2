using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class InscricaoEventoViewModel
    {
        public InscricaoEventoViewModel()
        {

        }

        public InscricaoEventoViewModel(InscricaoEvento inscricaoevento)
        {   
            IdInscricaoEvento = inscricaoevento.IdInscricaoEvento;
            TipoIngresso = inscricaoevento.TipoIngresso;
            IdEvento = inscricaoevento.IdEvento;
            IdParticipante = inscricaoevento.IdParticipante;
            IdEventoNavigation = inscricaoevento.IdEventoNavigation?.Nome;
            IdParticipanteNavigation = inscricaoevento.IdParticipanteNavigation?.Nome;
        }
        
        public int IdInscricaoEvento { get; set; }
        
        public string TipoIngresso { get; set; }
        
        public int? IdEvento { get; set; }
        
        public int? IdParticipante { get; set; }
        
        public string? IdEventoNavigation { get; set; }
        public string? IdParticipanteNavigation { get; set; }
        
        

        
        
    }
}