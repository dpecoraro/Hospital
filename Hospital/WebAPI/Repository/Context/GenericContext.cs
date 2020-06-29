using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Context
{
    //Definir depois métodos para gerar Log do Repositório
    public class GenericContext : DbContext
    {
        public GenericContext(DbContextOptions options) : base(options)
        {
        }

        protected GenericContext()
        {
        }
    }
}
