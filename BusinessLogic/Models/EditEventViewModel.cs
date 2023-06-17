using BusinessLogic.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class EditEventViewModel
    {
        public EditEventViewModel()
        {

        }

        public EditEventViewModel(Evento evento)
        {   
            IdEvento = evento.IdEvento;
            Nome = evento.Nome;
            DataString = evento.Data.ToString();
            HoraString = evento.Hora.ToString();
            CapacidademaxString = evento.Capacidademax.ToString();
            Local = evento.Local;
            Descricao = evento.Descricao;
            Categoria = evento.Categoria;
            Organizador = evento.IdOrganizador;
            NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;
        }

        public string? NomeOrganizador { get; set; }

        public int? Organizador { get; set; }

        public string? Categoria { get; set; }

        public int? Capacidademax
        {
            get { return int.Parse(CapacidademaxString); }
            set { CapacidademaxString = value?.ToString(); }
        }

        public string? Descricao { get; set; }

        public string? Local { get; set; }

        public string DataString { get; set; }

        public string HoraString { get; set; }
        
        public string CapacidademaxString { get; set; }

        public string DataAsString
        {
            get { return Data.ToString(); }
            set { DataString = value; }
        }

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

        public DateOnly Data
        {
            get
            {
                if (string.IsNullOrEmpty(DataString))
                    return default; // Retorna o valor padrão se DataString for nulo ou vazio
                return DateOnly.Parse(DataString);
            }
            set
            {
                DataString = value.ToString();
            }
        }


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
