using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdVerificationService.EntityFrameworkCore;
using IdVerificationService.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IdVerificationService.Web.Tests
{
    [DependsOn(
        typeof(IdVerificationServiceWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IdVerificationServiceWebTestModule : AbpModule
    {
        public IdVerificationServiceWebTestModule(IdVerificationServiceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdVerificationServiceWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IdVerificationServiceWebMvcModule).Assembly);
        }
    }
}