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
        }

        public int IdInscricaoAtividade { get; set; }

        public int? IdParticipante { get; set; }

        public int? IdAtividade { get; set; }
    }
}