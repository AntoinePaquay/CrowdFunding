﻿using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class ArticleMappers
    {
        public static Article ToModel(this BLL.Entities.ArticleEntity e)
        {
            return new Article
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Created = e.Created,
                LastModified = e.LastModified,
                Text = e.Text
            };
        }

        public static BLL.Entities.ArticleEntity ToBLL(this ArticleForm e)
        {
            return new BLL.Entities.ArticleEntity
            {
                ProjectId = e.ProjectId,
                Text = e.Text
            };
        }
    }
}
