using CrowdFunding.BLL.Entities;
using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public class ArticleService : IRepository<int, ArticleEntity>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ArticleEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ArticleEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ArticleEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
