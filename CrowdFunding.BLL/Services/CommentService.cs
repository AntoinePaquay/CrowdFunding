using CrowdFunding.BLL.Entities;
using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public class CommentService : IRepository<int, CommentEntity>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommentEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(CommentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
