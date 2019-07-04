using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Article: FullAuditModel
    {
         public string CatName { get; set; }
        public string Topic { get; set; } // tên của lesson 
        public string Content { get; set; }
        public int UserId { get; set; }
        public string Mark { get; set; }
    }
}
