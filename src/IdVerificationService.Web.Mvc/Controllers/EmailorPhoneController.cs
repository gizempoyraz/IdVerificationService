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
using System.IO;

namespace IdVerificationService.Web.Controllers
{
    public class EmailorPhoneController : IdVerificationServiceControllerBase
    {

        public object HttpCacheability { get; private set; }
        private readonly INviAppService _nviAppService;
        private IActionResult email;

        public EmailorPhoneController(INviAppService nviAppService)
        {
            _nviAppService = nviAppService;
        }


        public IActionResult Index(string auth)
        {
            ViewBag.IsError = false;

            try
            {
                var data = JsonConvert.DeserializeObject<KimlikBilgileriniDogrulaInput>(Services.NviAppService.Decrypt(HttpUtility.UrlDecode(auth)));
                var personData = _nviAppService.GetPersonByCitizenId(data.CitizenId);
                if (personData != null)
                {
                    if (string.IsNullOrEmpty(personData.Email) || !personData.Email.Contains('@'))
                        return email;

                    string[] emailArr = personData.Email.Split('@');
                    string domainExt = Path.GetExtension(personData.Email);

                    string maskedEmail = string.Format("{0}****{1}@{2}****{3}{4}",
                        emailArr[0][0],
                        emailArr[0].Substring(emailArr[0].Length - 1),
                        emailArr[1][0],
                        emailArr[1].Substring(emailArr[1].Length - domainExt.Length - 1, 1),
                        domainExt
                        );

                    
                    ViewBag.Email = maskedEmail;
                    ViewBag.PhoneNumber = personData.PhoneNumber;
                   

                    return View();
                }
                else
                {
                    ViewBag.IsError = true;
                    return View();
                }

            }
            catch
            {
                return Redirect("/Validation");
            }


        }
    }
    
}

