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
        Data = evento.Data.HasValue ? evento.Data.Value : default;
        HoraString = evento.Hora.ToString();
        CapacidademaxString = evento.Capacidademax.ToString();
        Local = evento.Local;
        Descricao = evento.Descricao;
        Categoria = evento.Categoria;
        IdOrganizador = evento.IdOrganizador;
        NomeOrganizador = evento.IdOrganizadorNavigation?.Nome;
        

    }
    


    public int IdEvento { get; set; }
    
    public string? Nome { get; set; }

    public string? Categoria { get; set; }
    
    public string HoraString { get; set; }

    public int? Capacidademax
    {
        get { return int.Parse(CapacidademaxString); }
    }

    public string? Descricao { get; set; }

    public string? Local { get; set; }
    
    public string CapacidademaxString { get; set; }

    public TimeOnly Hora
    {
        get
        {
            return TimeOnly.Parse(HoraString);
        }
    }

    public DateOnly? Data { get; set; }
    
    
    public int? IdOrganizador { get; set; }
    public string? NomeOrganizador { get; set; }


}