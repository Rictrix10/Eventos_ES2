using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class AddEventViewModelV2
{
    public AddEventViewModelV2()
    {
        
    }
    
    public AddEventViewModelV2(Evento evento)
    {
        IdEvento = evento.IdEvento;
        Nome = evento.Nome;
        //Data = evento.Data;
        Data = evento.Data.HasValue ? evento.Data.Value : default;
        Hora = evento.Hora;
        Local = evento.Local;
        Descricao = evento.Descricao;
        Capacidademax = evento.Capacidademax;
        Categoria = evento.Categoria;
        /*
        Organizador = evento.IdOrganizador;
        NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;
        */

    }

    public int IdEvento { get; set; }

    public int? Organizador { get; set; }

    public string? Categoria { get; set; }

    public int? Capacidademax { get; set; }

    public string? Descricao { get; set; }

    public string? Local { get; set; }

    public TimeOnly? Hora { get; set; }

    public DateOnly? Data { get; set; }

// Dentro do construtor
    

    public string? Nome { get; set; }
    
    public string? NomeOrganizador { get; set; }


}