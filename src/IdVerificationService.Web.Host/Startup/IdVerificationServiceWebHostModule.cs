using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdVerificationService.Configuration;

namespace IdVerificationService.Web.Host.Startup
{
    [DependsOn(
       typeof(IdVerificationServiceWebCoreModule))]
    public class IdVerificationServiceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdVerificationServiceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdVerificationServiceWebHostModule).GetAssembly());
        }
    }
}
