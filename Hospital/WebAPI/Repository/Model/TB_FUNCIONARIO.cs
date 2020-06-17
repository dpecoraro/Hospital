using BUSINESSLOGIC.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public class TB_FUNCIONARIO : Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Bonus => Salario * 0.5M; //melhorar tratamento criando interface própria para cálculo de Rendimento do Hospital

        public Cargo Cargo { get; set; }

        [Column(TypeName = "int")]
        public int? CRM { get; set; }

        public TB_ATENDIMENTO TB_ATENDIMENTO { get; set; }

        public IList<TB_ATENDIMENTO> Atendimentos { get; set; }
    }
}
