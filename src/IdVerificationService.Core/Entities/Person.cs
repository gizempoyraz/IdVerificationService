using Abp.Domain.Entities;
namespace IdVerificationService.EntityFrameworkCore
{
    public class Person:Entity
    {

        public long CitizenId { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }
    }

    }


   
    
