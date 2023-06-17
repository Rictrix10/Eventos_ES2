using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class AddEventoIngressoViewModel
{
    public AddEventoIngressoViewModel()
    {
        
    }
    
    public AddEventoIngressoViewModel(EventoIngresso eventoIngresso)
    {   
        IdIngresso = eventoIngresso.IdIngresso;
        Tipo_Ingresso = eventoIngresso.TipoIngresso;
        QuantidadeString = eventoIngresso.Quantidade.ToString();
        PrecoString = eventoIngresso.Preco.ToString();
        IdEvento = eventoIngresso.IdEvento;

    }

    public string? PrecoString { get; set; }

    public string? QuantidadeString { get; set; }

    public string? Tipo_Ingresso { get; set; }

    

    public decimal? Preco
    {
        get { return decimal.Parse(PrecoString); }
    }

    public int? Quantidade
    {
        get { return int.Parse(QuantidadeString); }
    }

    public int ?IdEvento { get; set; }

    public int IdIngresso { get; set; }
}