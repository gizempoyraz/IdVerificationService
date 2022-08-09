using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdVerificationService.Authorization;

namespace IdVerificationService
{
    [DependsOn(
        typeof(IdVerificationServiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdVerificationServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdVerificationServiceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdVerificationServiceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
