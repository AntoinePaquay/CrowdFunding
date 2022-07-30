using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class ProjectMappers
    {
        public static Project ToModel(this BLL.Entities.ProjectEntity e)
        {
            return new Project
            {
                Name = e.Name,
                Id = e.Id,
                CategoryId = e.CategoryId,
                MemberId = e.MemberId,
                Closing = e.Closing,
                Created = e.Created,
                Description = e.Description,
                LastModified = e.LastModified,
                Opening = e.Opening
            };
        }

        public static BLL.Entities.ProjectEntity ToBLL(this ProjectForm e)
        {
            return new BLL.Entities.ProjectEntity
            {
                Name = e.Name,
                CategoryId = e.CategoryId,
                MemberId = e.MemberId,
                Closing = e.Closing,
                Description = e.Description,
                Opening = e.Opening
            };
        }

    }
}
