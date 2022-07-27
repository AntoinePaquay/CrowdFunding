using CrowdFunding.BLL.Entities;
using CrowdFunding.BLL.Interfaces;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public class RewardService:IRewardService
    {
        private IRewardRepository _repository;
        public RewardService(IRewardRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<RewardEntity> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToBLL());
        }

        public RewardEntity GetById(int id)
        {
            return _repository.GetById(id).ToBLL();
        }

        public int Insert(RewardEntity entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(RewardEntity entity)
        {
            return _repository.Update(entity.ToDAL());
        }
    }
}
