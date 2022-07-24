using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class PrivateMessageMappers
    {
        public static BLL.Entities.PrivateMessageEntity ToBLL(this DAL.Entities.PrivateMessageEntity e)
        {
            return new BLL.Entities.PrivateMessageEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                RecipientId = e.RecipientId,
                SenderId = e.SenderId,
                Text = e.Text
            };
        }

        public static DAL.Entities.PrivateMessageEntity ToDAL(this BLL.Entities.PrivateMessageEntity e)
        {
            return new DAL.Entities.PrivateMessageEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                RecipientId = e.RecipientId,
                SenderId = e.SenderId,
                Text = e.Text
            };
        }
    }
}
