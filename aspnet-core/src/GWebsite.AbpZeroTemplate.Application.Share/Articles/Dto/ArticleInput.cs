using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Articles.Dto
{
    public class ArticleInput: Entity<int>
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
