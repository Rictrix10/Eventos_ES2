using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class AddAtividadeViewModel
    {
        public AddAtividadeViewModel()
        {

        }

        public AddAtividadeViewModel(Atividade atividade)
        {
            IdAtividade = atividade.IdAtividade;
            InscricaoAtividades = atividade.InscricaoAtividades;
            Nome = atividade.Nome;
            Data = atividade.Data;
            Hora = atividade.Hora;
            Descricao = atividade.Descricao;
            IdEvento = atividade.IdEvento;
            IdEventoNavigation = atividade.IdEventoNavigation;


        }

        public Evento IdEventoNavigation { get; set; }

        public int? IdEvento { get; set; }

        public string? Descricao { get; set; }

        public TimeOnly? Hora { get; set; }

        public DateOnly? Data { get; set; }

        public string? Nome { get; set; }

        public ICollection<InscricaoAtividade> InscricaoAtividades { get; set; }

        public int IdAtividade { get; set; }
    }
}