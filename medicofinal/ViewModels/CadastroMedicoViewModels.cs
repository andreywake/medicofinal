using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medicofinal.ViewModels
{
    public class CadastroMedicoViewModels
    {
        [Required(ErrorMessage = "Informe o CRM")]
        [MaxLength(10, ErrorMessage = "Máximo 10")]
        public String CRM { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Máximo 50")]
        public String Nome { get; set; }


        [Required(ErrorMessage = "Informe o endereço")]
        [MaxLength(255, ErrorMessage = "Máximo 255")]
        public String Endereco { get; set; }


        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(70, ErrorMessage = "Máximo 70")]
        public String Email { get; set; }
    }
}