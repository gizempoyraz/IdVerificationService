using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdVerificationService.Configuration;
using IdVerificationService.EntityFrameworkCore;
using IdVerificationService.Migrator.DependencyInjection;

namespace IdVerificationService.Migrator
{
    [DependsOn(typeof(IdVerificationServiceEntityFrameworkModule))]
    public class IdVerificationServiceMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public IdVerificationServiceMigratorModule(IdVerificationServiceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(IdVerificationServiceMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                IdVerificationServiceConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdVerificationServiceMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
