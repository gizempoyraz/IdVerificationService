using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdVerificationService.Controllers
{
    public abstract class IdVerificationServiceControllerBase: AbpController
    {
        protected IdVerificationServiceControllerBase()
        {
            LocalizationSourceName = IdVerificationServiceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
