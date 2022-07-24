using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransactionRepository:RepoBase<int,TransactionEntity>,ITransactionRepo
    {
        public TransactionRepository(IDbConnection connection)
            :base(connection,"Transaction","Id")
        { }

        public override int Insert(TransactionEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Transaction([ProjectId], [MemberId], [Amout])" +
                            "OUTPUT insert.[Id]" +
                            "Values(@ProjectId, @MemberId, @Amount)";


            AddParameter(cmd, "@ProjectId", entity.ProjectId);
            AddParameter(cmd, "@MemberId", entity.MemberId);
            AddParameter(cmd, "@Amount", entity.Amount);


            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        //Update implemanter avec l'interface mais non utiliser
        public override bool Update(TransactionEntity entity)
        {
            throw new NotSupportedException();
        }

        protected override TransactionEntity Convert(IDataRecord record)
        {
            //TODO verifier les null en db
            return new TransactionEntity
            {
                Id = (int)record["Id"],
                ProjectId = (int)record["ProjectId"],
                MemberId=(int)record["MemberId"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                Amount= (decimal)record["Amount"],

            };
        }
    }
}
