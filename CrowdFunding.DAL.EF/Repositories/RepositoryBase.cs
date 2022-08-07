using CrowdFunding.DAL.Context;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    internal class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> 
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        protected CrowdfundingContext _context;

        public RepositoryBase(CrowdfundingContext Context)
        {
            _context = Context;
        }

        public virtual bool Delete(TKey id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            return _context.SaveChanges() == 1;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();        
        }

        public TEntity GetById(TKey id)
        {
            
            return _context.Set<TEntity>().FirstOrDefault(e => EqualityComparer<TKey>.Default.Equals(e.Id, id));
        }

        public bool Insert(TEntity entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public bool Update(TEntity entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
