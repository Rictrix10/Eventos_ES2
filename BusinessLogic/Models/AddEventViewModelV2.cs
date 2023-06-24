using BusinessLogic.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class AddEventViewModelV2
    {
        public int IdEvento { get; set; }
        
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        public string Categoria { get; set; }
        
        [Required(ErrorMessage = "O campo Hora é obrigatório.")]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "O formato de hora é inválido.")]
        public string HoraString { get; set; }

        [Required(ErrorMessage = "O campo Capacidade máxima é obrigatório.")]
        [RegularExpression("^[0-9]{1,6}$", ErrorMessage = "A capacidade máxima deve conter no máximo 6 caracteres numéricos.")]
        public string CapacidademaxString { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public DateOnly? Data { get; set; }
        
        public int? IdOrganizador { get; set; }

        public string NomeOrganizador { get; set; }

        public AddEventViewModelV2()
        {
        }
        
        public AddEventViewModelV2(Evento evento)
        {
            IdEvento = evento.IdEvento;
            Nome = evento.Nome;
            Data = evento.Data.HasValue ? evento.Data.Value : default;
            HoraString = evento.Hora.ToString();
            CapacidademaxString = evento.Capacidademax.ToString();
            Local = evento.Local;
            Descricao = evento.Descricao;
            Categoria = evento.Categoria;
            IdOrganizador = evento.IdOrganizador;
            NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;
        }

        public int? Capacidademax
        {
            get { return int.Parse(CapacidademaxString); }
        }

        public TimeOnly Hora
        {
            get { return TimeOnly.Parse(HoraString); }
        }
    }
}

