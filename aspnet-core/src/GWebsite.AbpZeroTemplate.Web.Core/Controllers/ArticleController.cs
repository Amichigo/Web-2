using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Articles;
using GWebsite.AbpZeroTemplate.Application.Share.Articles.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ArticleController: GWebsiteControllerBase
    {
        private readonly IArticleAppService articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            this.articleAppService = articleAppService;
        }

        [HttpGet]
        public PagedResultDto<ArticleDto> GetArticlesByFilter(ArticleFilter articleFilter)
        {
            return articleAppService.GetArticles(articleFilter);
        }

        [HttpGet]
        public ArticleInput GetArticleForEdit(int id)
        {
            return articleAppService.GetArticleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditArticle([FromBody] ArticleInput input)
        {
            articleAppService.CreateOrEditArticle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteArticle(int id)
        {
            articleAppService.DeleteArticle(id);
        }

        [HttpGet]
        public ArticleForView GetArticleForView(int id)
        {
            return articleAppService.GetArticleForView(id);
        }
    }
}
