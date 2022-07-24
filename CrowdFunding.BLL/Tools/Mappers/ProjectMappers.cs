using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ProjectMappers
    {
        public static BLL.ProjectEntity ToBLL(this DAL.ProjectEntity e)
        {
            return new BLL.ProjectEntity()
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

        public static DAL.ProjectEntity ToDAL(this BLL.ProjectEntity e)
        {
            return new DAL.ProjectEntity()
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
