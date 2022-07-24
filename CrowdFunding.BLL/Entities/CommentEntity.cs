using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
