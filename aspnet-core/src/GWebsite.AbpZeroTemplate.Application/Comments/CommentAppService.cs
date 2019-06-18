using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Comments;
using GWebsite.AbpZeroTemplate.Application.Share.Comments.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Comments
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Comment)]
    class CommentAppService : GWebsiteAppServiceBase, ICommentAppService
    {
        private readonly IRepository<Comment> commentRepository;

        public CommentAppService(IRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        #region Public Method

        public void CreateOrEditComment(CommentInput commentInput)
        {
            if (commentInput.Id == 0)
            {
                Create(commentInput);
            }
            else
            {
                Update(commentInput);
            }
        }

        public void DeleteComment(int id)
        {
            var commentEntity = commentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (commentEntity != null)
            {
                commentEntity.IsDelete = true;
                commentRepository.Update(commentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CommentInput GetCommentForEdit(int id)
        {
            var commentEntity = commentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (commentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CommentInput>(commentEntity);
        }


        public PagedResultDto<CommentDto> GetComments(CommentFilter input)
        {
            var query = commentRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            query = query.Where(x => x.UserId.Equals(input.UserId));

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<CommentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CommentDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Comment_Create)]
        private void Create(CommentInput input)
        {
            var commentEntity = ObjectMapper.Map<Comment>(input);
            SetAuditInsert(commentEntity);
            commentRepository.Insert(commentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Comment_Edit)]
        private void Update(CommentInput input)
        {
            var commentEntity = commentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (commentEntity == null)
            {
            }
            ObjectMapper.Map(input, commentEntity);
            SetAuditEdit(commentEntity);
            commentRepository.Update(commentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
