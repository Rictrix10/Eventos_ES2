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
            InscricaoAtividades = atividade.InscricaoAtividades;
            Nome = atividade.Nome;
            Data = atividade.Data;
            Hora = atividade.Hora;
            Descricao = atividade.Descricao;
            IdEvento = atividade.IdEvento;
            IdEventoNavigation = atividade.IdEventoNavigation;
            EventoData = atividade.IdEventoNavigation?.Data;
            EventoHora = atividade.IdEventoNavigation?.Hora;
            


        }
        
        

        public Evento IdEventoNavigation { get; set; }

        public int? IdEvento { get; set; }

        public string? Descricao { get; set; }

        public TimeOnly? Hora { get; set; }

        public DateOnly? Data { get; set; }

        public string? Nome { get; set; }

        public ICollection<InscricaoAtividade> InscricaoAtividades { get; set; }

        public int IdAtividade { get; set; }
        
        public DateOnly? EventoData { get; set; }
        
        public TimeOnly? EventoHora { get; set; }
    }
}