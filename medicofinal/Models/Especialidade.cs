using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medicofinal.Models
{
    [Table("Especialidade")]
    public class Especialidade
    {
        public int EspecialidadeID { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nome { get; set; }
    }
}