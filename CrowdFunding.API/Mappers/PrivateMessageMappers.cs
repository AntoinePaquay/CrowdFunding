using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class PrivateMessageMappers
    {
        public static PrivateMessage ToModel(this BLL.Entities.PrivateMessageEntity e)
        {
            return new PrivateMessage
            {
                Id = e.Id,
                SenderId = e.SenderId,
                RecipientId = e.RecipientId,
                Created = e.Created,
                LastModified = e.LastModified,
                Text = e.Text
            };
        }

        public static BLL.Entities.PrivateMessageEntity ToBLL(this PrivateMessageForm e)
        {
            return new BLL.Entities.PrivateMessageEntity
            {
                SenderId = e.SenderId,
                RecipientId = e.RecipientId,
                Text = e.Text
            };
        }
    }
}
