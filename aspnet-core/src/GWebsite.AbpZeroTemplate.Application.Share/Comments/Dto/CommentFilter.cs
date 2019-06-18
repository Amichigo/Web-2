using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Comments.Dto
{
    public class CommentFilter: PagedAndSortedInputDto
    {
        public int UserId { get; set; }
    }
}
