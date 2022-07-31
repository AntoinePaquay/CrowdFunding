using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class RewardMappers
    {
        public static Reward ToModel(this BLL.Entities.RewardEntity e)
        {
            return new Reward
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Created = e.Created,
                Delivery = e.Delivery,
                Description = e.Description,
                LastModified = e.LastModified,
                Name = e.Name,
                Price = e.Price,
                Stock = e.Stock
            };
        }

        public static BLL.Entities.RewardEntity ToBLL(this RewardForm e)
        {
            return new BLL.Entities.RewardEntity
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Delivery = e.Delivery,
                Description = e.Description,
                Name = e.Name,
                Price = e.Price,
                Stock = e.Stock
            };
        }
    }
}
