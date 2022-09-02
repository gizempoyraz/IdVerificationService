using IdVerificationService.Controllers;
using IdVerificationService.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Web;

namespace IdVerificationService.Web.Controllers
{
    public class EmailorPhoneController : IdVerificationServiceControllerBase
    {
        public object HttpCacheability { get; private set; }

        public IActionResult Index(string auth)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<KimlikBilgileriniDogrulaInput>(Services.NviAppService.Decrypt(HttpUtility.UrlDecode(auth)));

                return View();
            }
            catch
            {
                return Redirect("/Validation");
            }

            
        }
       
    }
}
