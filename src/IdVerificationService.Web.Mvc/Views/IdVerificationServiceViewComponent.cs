using Abp.AspNetCore.Mvc.ViewComponents;

namespace IdVerificationService.Web.Views
{
    public abstract class IdVerificationServiceViewComponent : AbpViewComponent
    {
        protected IdVerificationServiceViewComponent()
        {
            LocalizationSourceName = IdVerificationServiceConsts.LocalizationSourceName;
        }
    }
}
