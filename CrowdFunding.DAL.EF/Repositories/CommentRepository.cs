using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public class CommentRepository : RepositoryBase<int, Comment>, ICommentRepository
    {
    }
}
