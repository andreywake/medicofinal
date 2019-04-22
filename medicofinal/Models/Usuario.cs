using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medicofinal.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nome { get; set; }

        [Required]
        [MaxLength(20)]
        public String Login { get; set; }

        [Required]
        [MinLength(5)]
        public String Senha { get; set; }
    }
}