using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public class TB_MEDICAMENTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public double Dosagem { get; set; }

        public TB_ATENDIMENTO TB_ATENDIMENTO { get; set; }
    }
}
