using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectRepo: RepoBase<int,ProjectEntity>,IProjectRepo
    {
        public ProjectRepo(IDbConnection connection)
            :base(connection,"Project","Id")
        { }

        public override int Insert(ProjectEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Project([Name], [Description], [Opening], [Closing], [MemberId], [CategoryId])" +
                            "OUTPUT insert.[Id]" +
                            "Values(@Name, @Description, @Opening, @Closing, @MemberId, @CategoryId)";


            AddParameter(cmd, "@Name", entity.Name);
            AddParameter(cmd, "@Description", entity.Description);
            AddParameter(cmd, "@Opening", entity.Opening);
            AddParameter(cmd, "@Closing", entity.Closing);
            AddParameter(cmd, "@MemberId", entity.MemberId);
            AddParameter(cmd, "@MemberId", entity.CategoryId);
            

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(ProjectEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Project SET " +
                    "Name = @Name, "+
                    "Descption= @Description"+
                    "Closing =@Cloding"+
                    "CategoryId=@CategoryId"+
                    "WHERE [Id]=@Id";


                AddParameter(cmd, "@Name", entity.Name);
                AddParameter(cmd, "@Description", entity.Description);
                AddParameter(cmd, "@Closing", entity.Closing);
                AddParameter(cmd, "@MemberId", entity.CategoryId);


                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override ProjectEntity Convert(IDataRecord record)
        {
            //TODO verifier les null en db
            return new ProjectEntity
            {
                Id = (int)record["Id"],
                Name= (string)record["Name"],
                Description= (string)record["Description"],
                Opening = (DateTime)record["Opening"],
                Closing=(DateTime)record["Closing"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                MemberId= (int)record["MemberId"],
                CategoryId = (int)record["CategoryId"]
            };
        }
    }
}
