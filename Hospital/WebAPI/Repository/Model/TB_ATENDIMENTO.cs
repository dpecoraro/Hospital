using BUSINESSLOGIC.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public class TB_ATENDIMENTO
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime HoraEntrada { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? HoraSaida { get; set; }

        public String Diagnostico { get; set; }

        public TB_FUNCIONARIO TB_FUNCIONARIO { get; set; }

        public TB_PACIENTE TB_PACIENTE { get; set; }

        public List<TB_MEDICAMENTO> Medicamentos { get; set; }

        public IList<TB_FUNCIONARIO> Funcionarios { get; set; }

        public IList<TB_PACIENTE> Pacientes { get; set; }

        public ClassificacaoDeRisco ClassificacaoDeRisco { get; set; }

        public bool Retorno { get; set; }
    }
}
