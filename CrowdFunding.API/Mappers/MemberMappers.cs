using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class MemberMappers
    {
        public static Member ToModel(this BLL.Entities.MemberEntity e)
        {
            return new Member
            {
                Id = e.Id,
                Image = e.Image,
                BirthDate = e.BirthDate,
                Created = e.Created,
                Email = e.Email,
                FirstName = e.FirstName,
                LastModified = e.LastModified,
                LastName = e.LastName,
                PasswordHash = e.PasswordHash,
                Username = e.Username
            };
        }

        public static BLL.Entities.MemberEntity ToBLL(this MemberForm e)
        {
            return new BLL.Entities.MemberEntity
            {
                Image = e.Image,
                BirthDate = e.BirthDate,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                PasswordHash = e.PasswordHash,
                Username = e.Username
            };
        }
    }
}
