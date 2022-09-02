using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdVerificationService.Authorization.Roles;
using IdVerificationService.Authorization.Users;
using IdVerificationService.MultiTenancy;
using System.ComponentModel.DataAnnotations;
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
