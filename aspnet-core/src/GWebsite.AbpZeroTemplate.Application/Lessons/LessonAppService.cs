using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Lessons;
using GWebsite.AbpZeroTemplate.Application.Share.Lessons.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Lessons
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Lesson)]
    public class LessonAppService : GWebsiteAppServiceBase, ILessonAppService
    {
        private readonly IRepository<Lesson> lessonRepository;

        public LessonAppService(IRepository<Lesson> lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        #region Public Method

        public void CreateOrEditLesson(LessonInput lessonInput)
        {
            if (lessonInput.Id == 0)
            {
                Create(lessonInput);
            }
            else
            {
                Update(lessonInput);
            }
        }

        public void DeleteLesson(int id)
        {
            var lessonEntity = lessonRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (lessonEntity != null)
            {
                lessonEntity.IsDelete = true;
                lessonRepository.Update(lessonEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LessonInput GetLessonForEdit(int id)
        {
            var lessonEntity = lessonRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (lessonEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LessonInput>(lessonEntity);
        }

        public LessonForViewDto GetLessonForView(int id)
        {
            var lessonEntity = lessonRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (lessonEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LessonForViewDto>(lessonEntity);
        }

        public PagedResultDto<LessonDto> GetLessons(LessonFilter input)
        {
            var query = lessonRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.CatName != null)
            {
                query = query.Where(x => x.CatName.ToLower().Equals(input.CatName));
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
            return new PagedResultDto<LessonDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LessonDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(LessonInput lessonInput)
        {
            var lessonEntity = ObjectMapper.Map<Lesson>(lessonInput);
            SetAuditInsert(lessonEntity);
            lessonRepository.Insert(lessonEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(LessonInput lessonInput)
        {
            var lessonEntity = lessonRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == lessonInput.Id);
            if (lessonEntity == null)
            {
            }
            ObjectMapper.Map(lessonInput, lessonEntity);
            SetAuditEdit(lessonEntity);
            lessonRepository.Update(lessonEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
