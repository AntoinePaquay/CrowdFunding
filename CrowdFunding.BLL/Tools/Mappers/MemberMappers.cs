using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class MemberMappers
    {
        public static BLL.MemberEntity ToBLL(this DAL.MemberEntity e)
        {
            return new BLL.MemberEntity()
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
                RegisterDate = e.RegisterDate,
                Username = e.Username
            };
        }

        public static DAL.MemberEntity ToDAL(this BLL.MemberEntity e)
        {
            return new DAL.MemberEntity()
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
                RegisterDate = e.RegisterDate,
                Username = e.Username
            };
        }

    }
}
