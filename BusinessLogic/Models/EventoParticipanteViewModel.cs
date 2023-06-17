using BusinessLogic.Entities;
using System;

namespace BusinessLogic.Models
{
    public class EventoParticipanteViewModel
    {
        public EventoParticipanteViewModel()
        {
        }

        public EventoParticipanteViewModel(Evento evento)
        {
            IdEvento = evento.IdEvento;
            Nome = evento.Nome;
            Data = evento.Data;
            Hora = evento.Hora;
            Local = evento.Local;
            Descricao = evento.Descricao;
            Capacidademax = evento.Capacidademax;
            Categoria = evento.Categoria;
        }

        public int IdEvento { get; set; }
        public int? Organizador { get; set; }
        public string? Categoria { get; set; }
        public int? Capacidademax { get; set; }
        public string? Descricao { get; set; }
        public string? Local { get; set; }
        public TimeOnly? Hora { get; set; }
        public DateOnly? Data { get; set; }
        public string? Nome { get; set; }
        public string? NomeOrganizador { get; set; }
    }
}