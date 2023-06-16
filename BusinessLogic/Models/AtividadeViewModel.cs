using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class AtividadeViewModel
    {
        public AtividadeViewModel()
        {

        }

        public AtividadeViewModel(Atividade atividade)
        {
            IdAtividade = atividade.IdAtividade;
            Nome = atividade.Nome;
            Hora = atividade.Hora;
        }

        public TimeOnly? Hora { get; set; }

        public string? Nome { get; set; }

        public int IdAtividade { get; set; }
    }
}