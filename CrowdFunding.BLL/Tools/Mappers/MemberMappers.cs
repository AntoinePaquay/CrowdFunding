using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class MemberMappers
    {
        public static BLL.Entities.MemberEntity ToBLL(this DAL.Entities.MemberEntity e)
        {
            return new BLL.Entities.MemberEntity()
            {
                Id = e.Id,
                Image = e.Image,
                BirthDate = e.BirthDate,
                Created = e.Created,
                Email = e.Email,
                LastModified = e.LastModified,
                LastName = e.LastName,
                FirstName = e.FirstName,
                PasswordHash = e.PasswordHash,
                Username = e.Username
            };
        }

        public static DAL.Entities.MemberEntity ToDAL(this BLL.Entities.MemberEntity e)
        {
            return new DAL.Entities.MemberEntity()
            {
                Id = e.Id,
                Image = e.Image,
                BirthDate = e.BirthDate,
                Created = e.Created,
                Email = e.Email,
                LastModified = e.LastModified,
                LastName = e.LastName,
                FirstName = e.FirstName,
                PasswordHash = e.PasswordHash,
                Username = e.Username
            };
        }

    }
}
