using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    /// <summary>
    /// <model cref="Category"></model>
    /// </summary>
    public class CategoryDto : Entity<int>
    {
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string CatContent { get; set; }
    }
}
