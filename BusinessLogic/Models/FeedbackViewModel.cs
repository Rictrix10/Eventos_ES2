using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class FeedbackViewModel
    {
        public FeedbackViewModel()
        {

        }

        public FeedbackViewModel(Feedback feedback)
        {
            Feedback1 = feedback.Feedback1;
            IdFeedback = feedback.IdFeedback;
            IdEvento = feedback.IdEvento;
            IdParticipante = feedback.IdParticipante;
            IdParticipanteNavigation = feedback.IdParticipanteNavigation;
            IdEventoNavigation = feedback.IdEventoNavigation;
        }

        public Evento IdEventoNavigation { get; set; }

        public Utilizador IdParticipanteNavigation { get; set; }

        public int? IdParticipante { get; set; }

        public int? IdEvento { get; set; }

        public int IdFeedback { get; set; }

        public string? Feedback1 { get; set; }
    }
}