using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medicofinal.ViewModels
{
    public class CadastroEspecialidadeViewModels
    {
        [Required(ErrorMessage = "Informe o nome da especialidade")]
        [MaxLength(50, ErrorMessage = "Máximo 50")]
        public String Nome { get; set; }
    }
}