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
        Tipo_Ingresso = eventoIngresso.TipoIngresso;
        Quantidade = eventoIngresso.Quantidade;
        Preco = eventoIngresso.Preco;
        IdEvento = eventoIngresso.IdEvento;

    }
    
    public int IdIngresso { get; set; }
    public string? Tipo_Ingresso { get; set; }
    
    public int? Quantidade { get; set; }

    public decimal? Preco { get; set; }
    

    public int ?IdEvento { get; set; }
    
}