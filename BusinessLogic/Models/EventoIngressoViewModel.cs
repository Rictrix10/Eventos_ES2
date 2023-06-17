using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class EventoIngressoViewModel
{
    public EventoIngressoViewModel()
    {
        
    }
    
    public EventoIngressoViewModel(EventoIngresso eventoIngresso)
    {   
        IdIngresso = eventoIngresso.IdIngresso;
        IdEvento = eventoIngresso.IdEvento;
        Quantidade = eventoIngresso.Quantidade;
        Preco = eventoIngresso.Preco;
        Tipo_Ingresso = eventoIngresso.TipoIngresso;

    }

    public string? Tipo_Ingresso { get; set; }

    public decimal? Preco { get; set; }

    public int? Quantidade { get; set; }

    public int ?IdEvento { get; set; }

    public int IdIngresso { get; set; }
}