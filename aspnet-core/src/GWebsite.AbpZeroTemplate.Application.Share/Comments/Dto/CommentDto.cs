using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Comments.Dto
{
    public class CommentDto: Entity<int>
    {
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
