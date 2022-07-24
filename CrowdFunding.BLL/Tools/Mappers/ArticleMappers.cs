using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ArticleMappers
    {
        public static BLL.ArticleEntity ToBLL(this DAL.ArticleEntity e)
        {
            return new BLL.ArticleEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                ProjectId = e.ProjectId,
                Text = e.Text,
            };
        }

        public static DAL.ArticleEntity ToDAL(this BLL.ArticleEntity e)
        {
            return new DAL.ArticleEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                ProjectId = e.ProjectId,
                Text = e.Text,
            };
        }
    }
}
