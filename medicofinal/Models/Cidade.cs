using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medicofinal.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        public int CidadeID { get; set; }

        [Required]
        [MaxLength(70)]
        public String Nome { get; set; }
    }
}