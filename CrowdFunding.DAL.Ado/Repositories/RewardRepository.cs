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
    public class RewardRepository:RepositoryBase<int,RewardEntity>,IRewardRepository
    {
        public RewardRepository(IDbConnection connection)
            :base(connection,"Reward","Id")
        { }

        public override int Insert(RewardEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Reward([Name], [Description], [Price], [Stock], [ProjectId], [Delivery])" +
                            "OUTPUT insert.[Id]" +
                            "Values(@Name, @Description, @Price, @Stock, @ProjectId, @Delivery)";


            AddParameter(cmd, "@Name", entity.Name);
            AddParameter(cmd, "@Description", entity.Description);
            AddParameter(cmd, "@Price", entity.Stock);
            AddParameter(cmd, "@Stock", entity.Stock);
            AddParameter(cmd, "@ProjectId", entity.ProjectId);
            AddParameter(cmd, "@Delivery", entity.Delivery);
            


            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(RewardEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Reward SET " +
                    "Name = @Name, " +
                    "Descption= @Description" +
                    "Price =@Price" +
                    "Stock=@Stock" +
                    "Delivery=@Delivery" +
                    "WHERE [Id]=@Id";


                AddParameter(cmd, "@Name", entity.Name);
                AddParameter(cmd, "@Description", entity.Description);
                AddParameter(cmd, "@Price", entity.Stock);
                AddParameter(cmd, "@Stock", entity.Stock);
                AddParameter(cmd, "@Delivery", entity.Delivery);


                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override RewardEntity Convert(IDataRecord record)
        {
            return new RewardEntity
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Description = (string)record["Description"],
                Price = (int)record["Price"],
                Stock = (int)record["Stock"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                ProjectId = (int)record["ProjectId"],
                Delivery = (DateTime)record["Delivery"]
            };
        }
    }
}
