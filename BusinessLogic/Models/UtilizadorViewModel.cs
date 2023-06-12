using BusinessLogic.Entities;

namespace BusinessLogic.Models;

public class UtilizadorViewModel
{
    public UtilizadorViewModel()
    {
        
    }
    
    public UtilizadorViewModel(Utilizador utilizador)
    {
        this.Nome = utilizador.Nome;
        this.Email = utilizador.Email;
    }
    
    public string? Nome { get; set; }

    public string? Email { get; set; }
}