using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class UtilizadorViewModel
{
    public UtilizadorViewModel()
    {
        
    }
    
    public UtilizadorViewModel(Utilizador utilizador)
    {
        Username = utilizador.Username;
        Password = utilizador.Password;
        Nome = utilizador.Nome;
        Email = utilizador.Email;
        Telefone = utilizador.Telefone;
        Tipoutilizador = utilizador.IdUtilizador;
        Tipoautenticao = utilizador.IdAutenticacao;
    }

    public int? Tipoautenticao { get; set; }

    public int Tipoutilizador { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Nome { get; set; }

    public string? Password { get; set; }

    public string? Username { get; set; }
}