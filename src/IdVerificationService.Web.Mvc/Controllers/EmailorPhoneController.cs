using IdVerificationService.Controllers;
using IdVerificationService.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Web;
using IdVerificationService.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using IdVerificationService.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using Abp.Domain.Repositories;
using IdVerificationService.Services;
using System.Threading.Tasks;

namespace IdVerificationService.Web.Controllers
{
    public class EmailorPhoneController : IdVerificationServiceControllerBase
    {

        public object HttpCacheability { get; private set; }
        private readonly INviAppService _nviAppService;

        public EmailorPhoneController(INviAppService nviAppService)
        {
            _nviAppService = nviAppService;
        }

        public IActionResult Index(string auth)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<KimlikBilgileriniDogrulaInput>(Services.NviAppService.Decrypt(HttpUtility.UrlDecode(auth)));
                var personData = _nviAppService.GetPersonByCitizenId(data.CitizenId);

                ViewBag.Email = personData.Email;
                ViewBag.PhoneNumber = personData.PhoneNumber;

                return View();
            }
            catch
            {
                return Redirect("/Validation");
            }

        }
    }
}

