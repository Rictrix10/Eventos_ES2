using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class UtilizadorViewModel
    {
        public UtilizadorViewModel()
        {

        }

        public UtilizadorViewModel(Utilizador utilizador)
        {
            IdUtilizador = utilizador.IdUtilizador;
            Username = utilizador.Username;
            Nome = utilizador.Nome;
            Email = utilizador.Email;
            Password = utilizador.Password;
            Telefone = utilizador.Telefone;
            Tipo = utilizador.Tipo;
            Autenticacao_tipo = utilizador.Autenticacao;
            Id_Tipo_Utilizador = utilizador.IdTipoUtilizador;
            Tipo_Utilizador = utilizador.IdTipoUtilizadorNavigation?.Tipo;
            Tipo_Autenticacao = utilizador.IdAutenticacaoNavigation?.Tipo;
        }

        public int IdUtilizador { get; set; }

        public string? Autenticacao_tipo { get; set; }

        public string? Tipo { get; set; }

        public string? Nome { get; set; }
        
        public string? Email { get; set; }
        public string? Username { get; set; }
        
        public string? Password { get; set; }
        
        public string? Telefone { get; set; }
        public int? Id_Tipo_Utilizador { get; set; }

        public string? Tipo_Autenticacao { get; set; }
        public string? Tipo_Utilizador { get; set; }
        
        
        
        
        

        public bool VerifyCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
