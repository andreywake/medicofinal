using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medicofinal.ViewModels
{
    public class LoginViewModels
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe Senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimo 6 letras")]
        public string Senha { get; set; }
    }
}