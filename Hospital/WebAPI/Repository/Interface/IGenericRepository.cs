using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Repository.Interface
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
