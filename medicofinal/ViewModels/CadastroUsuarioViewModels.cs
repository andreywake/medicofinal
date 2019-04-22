using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medicofinal.ViewModels
{
    public class CadastroUsuarioViewModels
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Máximo 50")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(20, ErrorMessage = "Máximo 20")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Máximo 100")]
        [MinLength(5, ErrorMessage = "Minimo 5 caracteres")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Confirme a senha!!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [MinLength(5, ErrorMessage = "Minimo 5 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a comparação não estão iguais")]
        public String ConfirmacaoSenha { get; set; }
    }
}