using BusinessLogic.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {

        }

        public AddEventViewModel(Evento evento)
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
        }


        public string? Descricao { get; set; }

        public string? Local { get; set; }

        public string DataString { get; set; }

        public string HoraString { get; set; }
        
        public string CapacidademaxString { get; set; }

        public DateOnly Data
        {
            get
            {
                return DateOnly.Parse(DataString);
            }
        }

        public TimeOnly Hora
        {
            get
            {
                return TimeOnly.Parse(HoraString);
            }
        }
        

        public string? Nome { get; set; }

        public int IdEvento { get; set; }
    }
}