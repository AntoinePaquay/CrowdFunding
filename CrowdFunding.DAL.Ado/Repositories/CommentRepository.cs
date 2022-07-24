using CrowdFunding.DAL.Entities;
using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
     public class CommentRepository:RepositoryBase<int, CommentEntity>,ICommentRepository
     {
        public CommentRepository(IDbConnection connection)
          : base(connection, "Article", "Id")
        { }

        public override int Insert(CommentEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Comment([Text], [MemberId], [ProjectId])" +
                             "OUTPUT inserted.[Id]" +
                             "Values(@Text, @MemberId, @ProjectId";

            AddParameter(cmd, "@Text", entity.Text);
            AddParameter(cmd, "@MemberId", entity.MemberId);
            AddParameter(cmd, "@ProjectId", entity.ProjectId);
       

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(CommentEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Comment SET " +
                    "Text = @Text"+
                    "WHERE [Id]=@Id";
                   

                AddParameter(cmd, "@Text", entity.Text);
             

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override CommentEntity Convert(IDataRecord record)
        {
            return new CommentEntity
            {
                Id = (int)record["Id"],
                ProjectId = (int)record["ProjectId"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                Text = (string)record["Text"],

            };
        }


     }

        
    
}
