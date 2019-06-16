using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    /// <summary>
    /// <model cref="Category"></model>
    /// </summary>
    public class CategoryForViewDto
    {
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string CatContent { get; set; }
    }
}
