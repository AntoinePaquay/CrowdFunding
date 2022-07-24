using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PrivateMessageMappers
    {
        public static BLL.PrivateMessageEntity ToBLL(this DAL.PrivateMessageEntity e)
        {
            return new BLL.PrivateMessageEntity()
            {
                Id = e.Id,
                Created = e.Created,
                LastModified = e.LastModified,
                RecipientId = e.RecipientId,
                SenderId = e.SenderId,
                Text = e.Text
            };
        }

        public static DAL.PrivateMessageEntity ToDAL(this BLL.PrivateMessageEntity e)
        {
            return new DAL.PrivateMessageEntity()
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
