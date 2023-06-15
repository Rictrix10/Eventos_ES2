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
            Username = utilizador.Username;
            Password = utilizador.Password;
        }
        public string? Password { get; set; }
        public string? Username { get; set; }

        public bool VerifyCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}