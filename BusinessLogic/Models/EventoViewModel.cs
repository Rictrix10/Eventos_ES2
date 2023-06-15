using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class EventoViewModel
{
    public EventoViewModel()
    {
        
    }
    
    public EventoViewModel(Evento evento)
    {
        Nome = evento.Nome;
        Data = evento.Data;
        Hora = evento.Hora;
        Local = evento.Local;
        Descricao = evento.Descricao;
        Capacidademax = evento.Capacidademax;
        Categoria = evento.Categoria;
        Organizador = evento.IdOrganizador;
        NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;

    }

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