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
    public class MemberService:IMemberService
    {
        private IMemberRepository _repository;
        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<MemberEntity> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToBLL());
        }

        public MemberEntity GetById(int id)
        {
            return _repository.GetById(id).ToBLL();
        }

        public int Insert(MemberEntity entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(MemberEntity entity)
        {
            return _repository.Update(entity.ToDAL());
        }
    }
}
