using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medicofinal.ViewModels
{
    public class AlterarSenhaViewModels
    {
        [Required(ErrorMessage = "Informe a senha senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string senhaAtual { get; set; }


        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string senhaNova { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare(nameof(senhaNova), ErrorMessage = "As senhas não conferem")]
        public string confirmacaoSenha { get; set; }
    }
}