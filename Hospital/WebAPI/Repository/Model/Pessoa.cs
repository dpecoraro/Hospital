using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }

        [StringLength(50)]
        public string RegistroGeral { get; set; }

        [Column(TypeName = "bigint")]
        public long Cpf { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataNascimento { get; set; }

        public TB_ENDERECO TB_ENDERECO { get; set; }

        [Column(TypeName = "int")]
        public int? TelefoneResidencial { get; set; }

        [Column(TypeName = "int")]
        public int? TelefoneCelular { get; set; }

        [Column(TypeName = "int")]
        public int? TelefoneComercial { get; set; }
    }
}
