using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class ArticleMappers
    {
        public static BLL.ArticleEntity ToBLL(this DAL.Article e)
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

        public static DAL.Article ToDAL(this BLL.ArticleEntity e)
        {
            return new DAL.Article()
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
