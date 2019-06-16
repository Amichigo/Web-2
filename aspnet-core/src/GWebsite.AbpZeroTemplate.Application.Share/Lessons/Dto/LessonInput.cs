using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lessons.Dto
{
    public class LessonInput : Entity<int>
    {
        public string IntroImage { get; set; }
        public string LessonContent { get; set; }
        public string Link { get; set; }
        public string CatName { get; set; }
    }
}
