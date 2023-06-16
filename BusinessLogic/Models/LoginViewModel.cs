using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public LoginViewModel(Utilizador utilizador)
        {
            IdUtilizador = utilizador.IdUtilizador;
            Username = utilizador.Username;
            Password = utilizador.Password;
            Tipo = utilizador.Tipo;
        }

        public string? Tipo { get; set; }

        public int IdUtilizador { get; set; }


        public string? Password { get; set; }
        public string? Username { get; set; }

        public bool VerifyCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
