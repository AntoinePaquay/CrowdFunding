using Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL
{
    public class ArticleService
    {
        private readonly CrowdfundingContext _context;
        public ArticleService(CrowdfundingContext context)
        {
            _context = context;
        }
        [return: MaybeNull]
        public IEnumerable<Article> GetArticlesFromProject(int projectId)
        {
            return _context.Find<Project>(projectId)?.Articles;
        }

        public bool Insert(Article a)
        {
            return _context.Add
        }
    }
}
