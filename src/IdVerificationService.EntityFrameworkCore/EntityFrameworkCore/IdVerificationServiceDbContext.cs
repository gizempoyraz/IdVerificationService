using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdVerificationService.Authorization.Roles;
using IdVerificationService.Authorization.Users;
using IdVerificationService.MultiTenancy;

namespace IdVerificationService.EntityFrameworkCore
{
    public class IdVerificationServiceDbContext : AbpZeroDbContext<Tenant, Role, User, IdVerificationServiceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public IdVerificationServiceDbContext(DbContextOptions<IdVerificationServiceDbContext> options)
            : base(options)
        {
        }
    }
}
