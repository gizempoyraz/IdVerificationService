using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdVerificationService.Configuration;

namespace IdVerificationService.Web.Startup
{
    [DependsOn(typeof(IdVerificationServiceWebCoreModule))]
    public class IdVerificationServiceWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdVerificationServiceWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<IdVerificationServiceNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdVerificationServiceWebMvcModule).GetAssembly());
        }
    }
}
