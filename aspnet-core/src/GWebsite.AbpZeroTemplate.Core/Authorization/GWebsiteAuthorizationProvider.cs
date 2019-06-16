using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class GWebsiteAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public GWebsiteAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public GWebsiteAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(GWebsitePermissions.Pages) ?? context.CreatePermission(GWebsitePermissions.Pages, L("Pages"));
            var gwebsite = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_GWebsite, L("GWebsite"));

            var menuClient = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient, L("MenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Create, L("CreatingNewMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Edit, L("EditingMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Delete, L("DeletingMenuClient"));

            var demoModel = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel, L("DemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Create, L("CreatingNewDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Edit, L("EditingDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Delete, L("DeletingDemoModel"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var comment = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Comment, L("Comment"));
            comment.CreateChildPermission(GWebsitePermissions.Pages_Administration_Comment_Create, L("CreatingNewComment"));
            comment.CreateChildPermission(GWebsitePermissions.Pages_Administration_Comment_Delete, L("DeletingComment"));
            comment.CreateChildPermission(GWebsitePermissions.Pages_Administration_Comment_Edit, L("EditingComment"));

            var article = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Article, L("Article"));
            article.CreateChildPermission(GWebsitePermissions.Pages_Administration_Article_Create, L("CreatingArticle"));
            article.CreateChildPermission(GWebsitePermissions.Pages_Administration_Article_Delete, L("DeletingArticle"));
            article.CreateChildPermission(GWebsitePermissions.Pages_Administration_Article_Edit, L("EditingArticle"));

            var category = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Category, L("Category"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Administration_Category_Create, L("CreatingNewCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Administration_Category_Edit, L("EditingCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Administration_Category_Delete, L("DeletingCategory"));

            var lesson = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Lesson, L("Lesson"));
            lesson.CreateChildPermission(GWebsitePermissions.Pages_Administration_Lesson_Create, L("CreatingNewLesson"));
            lesson.CreateChildPermission(GWebsitePermissions.Pages_Administration_Lesson_Edit, L("EditingLesson"));
            lesson.CreateChildPermission(GWebsitePermissions.Pages_Administration_Lesson_Delete, L("DeletingLesson"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
