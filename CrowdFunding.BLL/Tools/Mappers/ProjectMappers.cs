using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class ProjectMappers
    {
        public static BLL.Entities.ProjectEntity ToBLL(this DAL.Entities.ProjectEntity e)
        {
            return new BLL.Entities.ProjectEntity()
            {
                Id = e.Id,
                CategoryId = e.CategoryId,
                MemberId = e.MemberId,
                Closing = e.Closing,
                Created = e.Created,
                Description = e.Description,
                LastModified = e.LastModified,
                Name = e.Name,
                Opening = e.Opening
            };
        }

        public static DAL.Entities.ProjectEntity ToDAL(this BLL.Entities.ProjectEntity e)
        {
            return new DAL.Entities.ProjectEntity()
            {
                Id = e.Id,
                CategoryId = e.CategoryId,
                MemberId = e.MemberId,
                Closing = e.Closing,
                Created = e.Created,
                Description = e.Description,
                LastModified = e.LastModified,
                Name = e.Name,
                Opening = e.Opening
            };
        }
    }
}
