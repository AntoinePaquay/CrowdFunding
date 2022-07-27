using CrowdFunding.BLL.Entities;
using CrowdFunding.BLL.Interfaces;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToBLL());
        }

        public CommentEntity GetById(int id)
        {
            return _repository.GetById(id).ToBLL();
        }

        public int Insert(CommentEntity entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(CommentEntity entity)
        {
            return _repository.Update(entity.ToDAL());
        }
    }
}
