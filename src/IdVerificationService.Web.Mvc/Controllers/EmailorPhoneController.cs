using IdVerificationService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IdVerificationService.Web.Controllers
{
    public class EmailorPhoneController : IdVerificationServiceControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
