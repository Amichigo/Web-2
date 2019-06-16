using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Category : FullAuditModel
    {
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string CatContent { get; set; }
    }
}
