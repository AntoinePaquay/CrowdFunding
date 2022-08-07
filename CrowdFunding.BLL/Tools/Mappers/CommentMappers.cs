using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class CommentMappers
    {
        public static BLL.CommentEntity ToBLL(this DAL.Comment e)
        {
            return new BLL.CommentEntity
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Text = e.Text
            };
        }

        public static DAL.Comment ToDAL(this BLL.CommentEntity e)
        {
            return new DAL.Comment
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
