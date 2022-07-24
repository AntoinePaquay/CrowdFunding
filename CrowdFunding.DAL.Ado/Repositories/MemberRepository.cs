using CrowdFunding.DAL.Entities;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberRepository : RepositoryBase<int, MemberEntity>, IMemberRepository
    {
        public MemberRepository(IDbConnection connection)
            : base(connection, "Article", "Id")
        { }

        public override int Insert(MemberEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Memmber([LastName], [FirstName], [UserName], [Email], " +
                              "[PasswordHash], [BirthDate], [Image], [RegisterDate], [Created], [LastModified])" +
                              "OUTPUT insert.[Id]" +
                              "Values(@LastName, @FirstName, @UserName, @Email, @Pwd, @BD, @Img, @RegiDa)";


            AddParameter(cmd, "@LastName",entity.LastName );
            AddParameter(cmd, "@FirstName", entity.FirstName);
            AddParameter(cmd, "@UserName", entity.Username);
            AddParameter(cmd, "@Email", entity.Email);
            AddParameter(cmd, "@Pwd", entity.PasswordHash);
            AddParameter(cmd, "@BD", entity.BirthDate);
            AddParameter(cmd, "@Img", entity.Image);
           

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(MemberEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Member SET " +
                    "LastName = @LastName, " +
                    "FirstName= @FirstName, " +
                    "UserName= @UserName, " +
                    "Email= @Email, " +
                    "PasswordHash= @Pwd, " +
                    "BirthDate= @BD "+
                    "WHERE [Id]=@Id";
                   

                AddParameter(cmd, "@LastName", entity.LastName);
                AddParameter(cmd, "@FirstName", entity.FirstName);
                AddParameter(cmd, "@UserName", entity.Username);
                AddParameter(cmd, "@Email", entity.Email);
                AddParameter(cmd, "@Pwd", entity.PasswordHash);
                AddParameter(cmd, "@BD", entity.BirthDate);
                AddParameter(cmd, "@Img", entity.Image);
               

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override MemberEntity Convert(IDataRecord record)
        {
            //TODO verifier les null en db
            return new MemberEntity
            {
                Id = (int)record["Id"],
                LastName= (string)record["LastName"],
                FirstName=(string)record["FirstName"],
                Username=(string)record["UserName"],
                Email=(string)record["Email"],
                PasswordHash= (string)record["PasswordHash"],
                BirthDate=(DateTime)record["BirthDate"],
                Image=(string)record["Image"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                

            };
        }
    }


}
