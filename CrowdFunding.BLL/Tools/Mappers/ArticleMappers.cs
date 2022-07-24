using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class ArticleMappers
    {
        public static BLL.Entities.ArticleEntity ToBLL(this DAL.Entities.ArticleEntity e)
        {
            return new BLL.Entities.ArticleEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                ProjectId = e.ProjectId,
                Text = e.Text,
            };
        }

        public static DAL.Entities.ArticleEntity ToDAL(this BLL.Entities.ArticleEntity e)
        {
            return new DAL.Entities.ArticleEntity()
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
