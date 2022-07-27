using CrowdFunding.DAL.Entities;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public class PrivateMessageRepository : RepositoryBase<int,PrivateMessageEntity>, IPrivateMessageRepository
    {
        public PrivateMessageRepository(IDbConnection connection)
            :base(connection, "PrivateMessage", "Id")
        { }

        public override int Insert(PrivateMessageEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO PrivateMessage([SenderId], [RecipientId], [Text])" +
                            "OUTPUT insert.[Id]" +
                            "Values(@SenderId, @RecipientId, @Text)";


            AddParameter(cmd, "@SenderId", entity.SenderId);
            AddParameter(cmd, "@RecipientId", entity.RecipientId);
            AddParameter(cmd, "@Text", entity.Text);
         

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(PrivateMessageEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Article SET " +
                    "Text = @Text "+
                    "WHERE [Id]=@Id";
                    

                AddParameter(cmd, "@Text", entity.Text);
               

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override PrivateMessageEntity Convert(IDataRecord record)
        {
            //TODO verifier les null en db
            return new PrivateMessageEntity
            {
                Id = (int)record["Id"],
                SenderId = (int)record["SenderId"],
                RecipientId=(int)record["RecipientId"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                Text = (string)record["Text"],

            };
        }
    }
}
