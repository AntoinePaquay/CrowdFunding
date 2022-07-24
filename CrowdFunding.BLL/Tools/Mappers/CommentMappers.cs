using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class CommentMappers
    {
        public static BLL.Entities.CommentEntity ToBLL(this DAL.Entities.CommentEntity e)
        {
            return new BLL.Entities.CommentEntity
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Text = e.Text
            };
        }

        public static DAL.Entities.CommentEntity ToDAL(this BLL.Entities.CommentEntity e)
        {
            return new DAL.Entities.CommentEntity
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Text = e.Text
            };
        }
    }
}
