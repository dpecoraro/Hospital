using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPI.Repository.Context;
using WebAPI.Repository.Interface;

namespace WebAPI.Repository
{
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected GenericContext _context;
        private bool disposedValue;
        protected readonly TEntity _entity;

        public TEntity Get(object key) => _context.Set<TEntity>().Find(key);

        public TEntity Get(params object[] keys) => _context.Set<TEntity>().Find(keys);

        public IQueryable<TEntity> QueryAll() => _context.Set<TEntity>();

        public IQueryable<TEntity> QueryAll(Func<TEntity, bool> predicate) => _context.Set<TEntity>().Where(predicate).AsQueryable();

        public IList<TEntity> ListAll() => _context.Set<TEntity>().ToList();

        public IList<TEntity> ListAll(Func<TEntity, bool> predicate) => _context.Set<TEntity>().Where(predicate).ToList();

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Update(TEntity entity, string property) => _context.Entry(entity).Property(property).IsModified = true;

        public void Delete(Func<TEntity, bool> predicate) => _context.Set<TEntity>().Where(predicate).ToList().ForEach(delete => _context.Set<TEntity>().Remove(delete));

        public long SaveAll() => _context.SaveChanges();

        public async Task<long> SaveAllAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();


        #region [ Dispose ]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
