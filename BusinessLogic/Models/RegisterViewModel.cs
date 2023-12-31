﻿using BusinessLogic.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {

        }

        public RegisterViewModel(Utilizador utilizador)
        {
            Nome = utilizador.Nome;
            Email = utilizador.Email;
            Username = utilizador.Username;
            Password = utilizador.Password;
            Tipo = utilizador.Tipo;
            Autenticacao_tipo = utilizador.Autenticacao;
            Id_Tipo_Utilizador = utilizador.IdTipoUtilizador;
            Tipo_Utilizador = utilizador.IdTipoUtilizadorNavigation?.Tipo;

        }

        public string? Autenticacao_tipo { get; set; }

        public string? Tipo { get; set; }

        public int? Id_Tipo_Utilizador { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "A senha deve ter pelo menos 8 caracteres e conter letras maiúsculas, minúsculas e números.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public string Tipo_Utilizador { get; set; }

        public List<string> Tipo_UtilizadorOpcoes { get; set; } = new List<string>
        {
            "Organizador",
            "Participante",
        };
        
        
    }
}
