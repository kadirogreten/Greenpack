using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Context;
using System.Data.Entity;

namespace ServiceLayer.Repository
{
    [Serializable]
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly GreenpackDbContext _context;

        public GenericRepository(GreenpackDbContext context)
        {
            _context = context;
        }


        
        public IEnumerable<TEntity> GetAll()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Insert(TEntity entity)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Set<TEntity>().Remove(entity);
        }


    }
}
