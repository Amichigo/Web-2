using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Comments;
using GWebsite.AbpZeroTemplate.Application.Share.Comments.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CommentController: GWebsiteControllerBase
    {
        private readonly ICommentAppService commentAppService;
        public CommentController(ICommentAppService commentAppService)
        {
            this.commentAppService = commentAppService;
        }

        [HttpGet]
        public PagedResultDto<CommentDto> GetCommentsByFilter(CommentFilter commentFilter)
        {
            return commentAppService.GetComments(commentFilter);
        }

        [HttpGet]
        public CommentInput GetCommentForEdit(int id)
        {
            return commentAppService.GetCommentForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditComment([FromBody] CommentInput input)
        {
            commentAppService.CreateOrEditComment(input);
        }

        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            commentAppService.DeleteComment(id);
        }
    }
}
