using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public interface IRepository<TKey, TEntity>
    where TEntity : IEntity<TKey>
    {
        #region CRUD Interface
        bool Insert(TEntity entity);

        // - Read
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);

        // - Update
        bool Update(TEntity entity);

        // - Delete
        bool Delete(TKey id);


        #endregion
    }
}
