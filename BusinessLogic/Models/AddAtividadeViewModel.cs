using BusinessLogic.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BusinessLogic.Models
{
    public class AddAtividadeViewModel
    {
        public AddAtividadeViewModel()
        {
        }

        public AddAtividadeViewModel(Atividade atividade)
        {
            Nome = atividade.Nome;
            Data = atividade.Data.HasValue ? atividade.Data.Value : default;
            HoraString = atividade.Hora.ToString();
            Descricao = atividade.Descricao;
            IdEvento = atividade.IdEvento;
            EventoData = atividade.IdEventoNavigation?.Data;
            EventoHora = atividade.IdEventoNavigation?.Hora;
        }

        public int? IdEvento { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public DateOnly? Data { get; set; }

        [Required(ErrorMessage = "O campo Hora é obrigatório.")]
        public string HoraString { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        public TimeOnly Hora
        {
            get
            {
                return TimeOnly.Parse(HoraString);
            }
        }

        public DateOnly? EventoData { get; set; }

        public TimeOnly? EventoHora { get; set; }

        public ValidationResult Validate()
        {
            if (Data < EventoData)
            {
                return new ValidationResult("A data da atividade não pode ser anterior à data do evento.");
            }
            
            if (Data == EventoData && Hora < EventoHora)
            {
                return new ValidationResult("A hora da atividade não pode ser anterior à hora do evento.");
            }

            return ValidationResult.Success;
        }
    }
}
