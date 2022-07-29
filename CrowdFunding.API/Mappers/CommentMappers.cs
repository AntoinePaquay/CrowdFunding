using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class CommentMappers
    {
        public static Comment ToModel(this BLL.Entities.CommentEntity e)
        {
            return new Comment
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Created = e.Created,
                LastModified = e.LastModified,
                Text = e.Text
            };
        }

        public static BLL.Entities.CommentEntity ToBLL(this CommentForm e)
        {
            return new BLL.Entities.CommentEntity
            {
                Text = e.Text,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
            };
        }
    }
}
