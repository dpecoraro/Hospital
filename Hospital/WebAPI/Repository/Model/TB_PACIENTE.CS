using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public class TB_PACIENTE : Pessoa
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Convenio { get; set; }

        public TB_ATENDIMENTO TB_ATENDIMENTO { get; set; }

        public List<TB_ATENDIMENTO> Atendimentos { get; set; }
    }
}
