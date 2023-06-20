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
            IdParticipanteNavigationUsername = inscricaoevento.IdParticipanteNavigation?.Username;
            IdParticipanteNavigationEmail = inscricaoevento.IdParticipanteNavigation?.Email;
            IdParticipanteNavigationTelefone = inscricaoevento.IdParticipanteNavigation?.Telefone;
            IdOrganizador = inscricaoevento.IdEventoNavigation?.IdOrganizador;
            NomeOrganizador = inscricaoevento.IdEventoNavigation?.IdOrganizadorNavigation?.Nome;
        }
        

        public int IdInscricaoEvento { get; set; }
        
        public string TipoIngresso { get; set; }
        
        public int? IdEvento { get; set; }
        
        public int? IdParticipante { get; set; }
        
        public string? IdEventoNavigation { get; set; }
        public string? IdParticipanteNavigation { get; set; }
        
        public string? IdParticipanteNavigationUsername { get; set; }

        public string? IdParticipanteNavigationEmail { get; set; }

        public string? IdParticipanteNavigationTelefone { get; set; }
        
        public int? IdOrganizador { get; set; }
        
        public string? NomeOrganizador { get; set; }
        

        
        

        
        
    }
}