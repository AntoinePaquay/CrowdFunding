using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArticleRepo : RepoBase<int, ArticleEntity>, IArticleRepo
    {
        public ArticleRepo(IDbConnection connection)
            : base(connection, "Article", "Id")
        { }

        public override int Insert(ArticleEntity entity)
        {
            IDbCommand cmd = _Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Article([ProjectId], [Text])" +
                            "OUTPUT insert.[Id]" +
                            "Values(@ProjectId, @Text)";


            AddParameter(cmd, "@ProjectId", entity.ProjectId);
            AddParameter(cmd, "@Text", entity.Text);
           

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(ArticleEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {

                cmd.CommandText = "UPDATE Article SET " +
                    "Text = @Text"+
                    "WHERE [Id]=@Id";
                   

                AddParameter(cmd, "@Text", entity.Text);
                

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        protected override ArticleEntity Convert(IDataRecord record)
        {
            //TODO verifier les null en db
            return new ArticleEntity
            {
                Id = (int)record["Id"],
                ProjectId= (int)record["ProjectId"],
                Created = (DateTime)record["Created"],
                LastModified = (DateTime)record["LastModified"],
                Text = (string)record["Text"],
               
            };
        }
    }
}
