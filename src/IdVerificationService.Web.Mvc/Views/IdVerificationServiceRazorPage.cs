using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace IdVerificationService.Web.Views
{
    public abstract class IdVerificationServiceRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected IdVerificationServiceRazorPage()
        {
            LocalizationSourceName = IdVerificationServiceConsts.LocalizationSourceName;
        }
    }
}
