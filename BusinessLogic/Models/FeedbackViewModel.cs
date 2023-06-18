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
            IdFeedback = feedback.IdFeedback;
            Feedback1 = feedback.Feedback1;
            IdParticipante = feedback.IdParticipante;
            IdEvento = feedback.IdEvento;

        }
        
        public int IdFeedback { get; set; }
        public string? Feedback1 { get; set; }
        

        public int? IdParticipante { get; set; }

        public int? IdEvento { get; set; }
    }
}