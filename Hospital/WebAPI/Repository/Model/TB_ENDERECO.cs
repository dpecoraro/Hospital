using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Model
{
    public class TB_ENDERECO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Rua { get; set; }

        [Column(TypeName = "int")]
        public int Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [StringLength(15)]
        public string Estado { get; set; }

        [StringLength(12)]
        public string Cep { get; set; }
    }
}
