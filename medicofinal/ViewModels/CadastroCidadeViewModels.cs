using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medicofinal.ViewModels
{
    public class CadastroCidadeViewModels
    {
        [Required(ErrorMessage = "Informe o nome da cidade")]
        [MaxLength(70, ErrorMessage = "Máximo 70")]
        public String Nome { get; set; }
    }
}