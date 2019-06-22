using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Articles;
using GWebsite.AbpZeroTemplate.Application.Share.Articles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace GWebsite.AbpZeroTemplate.Web.Core.Articles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Article)]
    public class ArticleAppService: GWebsiteAppServiceBase, IArticleAppService
    {
        private readonly IRepository<Article> articleRepository;

        public ArticleAppService(IRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        #region Public Method

        public void CreateOrEditArticle(ArticleInput articleInput)
        {
            if (articleInput.Id == 0)
            {
                Create(articleInput);
            }
            else
            {
                Update(articleInput);
            }
        }

        public void DeleteArticle(int id)
        {
            var articleEntity = articleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (articleEntity != null)
            {
                articleEntity.IsDelete = true;
                articleRepository.Update(articleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ArticleInput GetArticleForEdit(int id)
        {
            var articleEntity = articleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (articleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ArticleInput>(articleEntity);
        }

        public ArticleForView GetArticleForView(int id)
        {
            var articleEntity = articleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (articleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ArticleForView>(articleEntity);
        }

        public PagedResultDto<ArticleDto> GetArticles(ArticleFilter input)
        {
            var query = articleRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Topic != null)
            {
                query = query.Where(x => x.Topic.ToLower().Contains(input.Topic));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ArticleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ArticleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Article_Create)]
        private void Create(ArticleInput articleInput)
        {
            var articleEntity = ObjectMapper.Map<Article>(articleInput);
            SetAuditInsert(articleEntity);
            articleRepository.Insert(articleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Article_Edit)]
        private void Update(ArticleInput articleInput)
        {
            var articleEntity = articleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == articleInput.Id);
            if (articleEntity == null)
            {
            }
            ObjectMapper.Map(articleInput, articleEntity);
            SetAuditEdit(articleEntity);
            articleRepository.Update(articleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
