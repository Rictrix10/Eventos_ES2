using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class AddAtividadeViewModel
{
    public AddAtividadeViewModel()
    {
        
    }
    
    public AddAtividadeViewModel(Atividade atividade)
    {
        Nome = atividade.Nome;
        Data = atividade.Data.HasValue ? atividade.Data.Value : default;
        HoraString = atividade.Hora.ToString();
        Descricao = atividade.Descricao;
        IdEvento = atividade.IdEvento;
        /*
        Organizador = evento.IdOrganizador;
        NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;
        */

    }

    public int? IdEvento { get; set; }
    
    
    public string HoraString { get; set; }
    

    public string? Descricao { get; set; }
    

    public TimeOnly Hora
    {
        get
        {
            return TimeOnly.Parse(HoraString);
        }
    }

    public DateOnly? Data { get; set; }

// Dentro do construtor
    

    public string? Nome { get; set; }
    


}
