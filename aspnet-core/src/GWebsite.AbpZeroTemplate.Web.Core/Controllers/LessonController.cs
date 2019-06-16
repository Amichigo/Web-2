using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lessons;
using GWebsite.AbpZeroTemplate.Application.Share.Lessons.Dto;
using Microsoft.AspNetCore.Mvc;


namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LessonController : GWebsiteControllerBase
    {
        private readonly ILessonAppService lessonAppService;

        public LessonController(ILessonAppService lessonAppService)
        {
            this.lessonAppService = lessonAppService;
        }

        [HttpGet]
        public PagedResultDto<LessonDto> GetLessonsByFilter(LessonFilter lessonFilter)
        {
            return lessonAppService.GetLessons(lessonFilter);
        }

        [HttpGet]
        public LessonInput GetLessonForEdit(int id)
        {
            return lessonAppService.GetLessonForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLesson([FromBody] LessonInput input)
        {
            lessonAppService.CreateOrEditLesson(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLesson(int id)
        {
            lessonAppService.DeleteLesson(id);
        }

        [HttpGet]
        public LessonForViewDto GetLessonForView(int id)
        {
            return lessonAppService.GetLessonForView(id);
        }
    }
}
