using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lessons.Dto
{
    public class LessonFilter : PagedAndSortedInputDto
    {
        public string CatName { get; set; }
    }
}
