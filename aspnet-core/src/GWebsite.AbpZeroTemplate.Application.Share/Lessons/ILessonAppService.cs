using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lessons.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lessons
{
    public interface ILessonAppService
    {
        void CreateOrEditLesson(LessonInput customerInput);
        LessonInput GetLessonForEdit(int id);
        void DeleteLesson(int id);
        PagedResultDto<LessonDto> GetLessons(LessonFilter input);
        LessonForViewDto GetLessonForView(int id);
    }
}
