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
    public class ProjectService:IProjectService
    {

        private IProjectRepository _repository;
        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<ProjectEntity> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToBLL());
        }

        public ProjectEntity GetById(int id)
        {
            return _repository.GetById(id).ToBLL();
        }

        public int Insert(ProjectEntity entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(ProjectEntity entity)
        {
            return _repository.Update(entity.ToDAL());
        }
    }
}
