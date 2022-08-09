using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using IdVerificationService.Controllers;

namespace IdVerificationService.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : IdVerificationServiceControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
