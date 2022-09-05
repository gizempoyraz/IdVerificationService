using Abp.AutoMapper;
using IdVerificationService.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerificationService.Services.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto
    {
        public long CitizenId { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }
    }
}
