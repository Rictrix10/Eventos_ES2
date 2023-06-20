using BusinessLogic.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class EditEventViewModel
    {
        public EditEventViewModel()
        {
            // Define os valores iniciais dos campos
            Nome = string.Empty;
            Data = default;
            HoraString = string.Empty;
            CapacidademaxString = string.Empty;
            Local = string.Empty;
            Descricao = string.Empty;
            Categoria = string.Empty;
            IdOrganizador = null;
            NomeOrganizador = string.Empty;
        }

        public EditEventViewModel(Evento evento)
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

        public int? IdOrganizador { get; set; }

        public string? NomeOrganizador { get; set; }

        

        public string? Categoria { get; set; }

        public int? Capacidademax
        {
            get
            {
                if (int.TryParse(CapacidademaxString, out int result))
                {
                    return result;
                }
                return null; // Ou defina um valor padrão apropriado
            }
            set { CapacidademaxString = value?.ToString(); }
        }

        public string? Descricao { get; set; }

        public string? Local { get; set; }

        public string DataString { get; set; }

        public string HoraString { get; set; }

        public string CapacidademaxString { get; set; }

        public string HoraAsString
        {
            get { return Hora.ToString(); }
            set { HoraString = value; }
        }

        public string CapacidademaxAsString
        {
            get { return Capacidademax.ToString(); }
            set { CapacidademaxString = value; }
        }

        public DateOnly? Data { get; set; }

        public TimeOnly Hora
        {
            get
            {
                return TimeOnly.Parse(HoraString);
            }
            set
            {
                HoraString = value.ToString();
            }
        }

        public string? Nome { get; set; }

        public int IdEvento { get; set; }
    }
}
