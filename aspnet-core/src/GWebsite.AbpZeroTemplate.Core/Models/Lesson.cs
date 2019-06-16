using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Lesson : FullAuditModel
    {
        public string IntroImage { get; set; }
        public string LessonContent { get; set; }
        public string Link { get; set; }
        public string CatName { get; set; }
    }
}
