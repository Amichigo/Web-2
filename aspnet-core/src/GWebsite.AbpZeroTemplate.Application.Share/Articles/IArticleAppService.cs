using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Articles
{
    public interface IArticleAppService
    {
        void CreateOrEditArticle(ArticleInput articleInput);
        ArticleInput GetArticleForEdit(int id);
        void DeleteArticle(int id);
        PagedResultDto<ArticleDto> GetArticles(ArticleFilter input);
        ArticleForView GetArticleForView(int id);
    }
}
