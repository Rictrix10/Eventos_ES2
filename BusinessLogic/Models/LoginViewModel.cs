using BusinessLogic.Entities;
using System.ComponentModel.DataAnnotations;

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
            Nome = utilizador.Nome;
            Username = utilizador.Username;
            Password = utilizador.Password;
            Tipo = utilizador.Tipo;
        }

        public string? Nome { get; set; }

        public string? Tipo { get; set; }

        public int IdUtilizador { get; set; }

        [Required(ErrorMessage = "O username é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public bool VerifyCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}

