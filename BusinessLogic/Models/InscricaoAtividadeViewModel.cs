using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class InscricaoAtividadeViewModel
    {
        public InscricaoAtividadeViewModel()
        {

        }

        public InscricaoAtividadeViewModel(InscricaoAtividade inscricaoatividade)
        {   
            IdInscricaoAtividade = inscricaoatividade.IdInscricaoAtividade;
            IdParticipante = inscricaoatividade.IdParticipante;
            IdAtividade = inscricaoatividade.IdAtividade;
            NomeAtividade = inscricaoatividade.IdAtividadeNavigation?.Nome;
            NomeParticipante = inscricaoatividade.IdParticipanteNavigation?.Nome;
            NomeEvento = inscricaoatividade.IdAtividadeNavigation?.IdEventoNavigation?.Nome;
        }
        

        public int IdInscricaoAtividade { get; set; }

        public int? IdParticipante { get; set; }

        public int? IdAtividade { get; set; }
        
        public string? NomeAtividade { get; set; }
        
        public string? NomeParticipante { get; set; }
        
        public string? NomeEvento { get; set; }
    }
}