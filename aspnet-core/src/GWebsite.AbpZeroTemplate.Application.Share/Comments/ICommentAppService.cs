using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Comments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Comments
{
    public interface ICommentAppService
    {
        void CreateOrEditComment(CommentInput commentInput);
        CommentInput GetCommentForEdit(int id);
        void DeleteComment(int id);
        PagedResultDto<CommentDto> GetComments(CommentFilter input);
    }
}
