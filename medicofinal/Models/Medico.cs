using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medicofinal.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int MedicoID { get; set; }

        public int EspecialidadeID { get; set; }

        [ForeignKey("EspecialidadeID")]
        public virtual Especialidade Especialidade { get; set; }

        public int CidadeID { get; set; }

        [ForeignKey("CidadeID")]
        public virtual Cidade Cidade { get; set; }

        [Required]
        [MaxLength(10)]
        public String CRM { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public String Endereco { get; set; }


        [Required]
        [MaxLength(70)]
        public String Email { get; set; }


        public Boolean Convenio { get; set; }

        public Boolean pClinica { get; set; }
    }
}