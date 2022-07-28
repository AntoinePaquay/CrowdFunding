using CrowdFunding.BLL.Entities;
using CrowdFunding.BLL.Interfaces;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public class TransactionService:ITransactionService
    {
        private ITransactionRepository _repository;
        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<TransactionEntity> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToBLL());
        }

        public TransactionEntity GetById(int id)
        {
            return _repository.GetById(id).ToBLL();
        }

        public int Insert(TransactionEntity entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(TransactionEntity entity)
        {
            return _repository.Update(entity.ToDAL());
        }
    }
}
