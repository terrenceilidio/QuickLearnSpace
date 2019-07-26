using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickLearnSpace.Configuration;
using QuickLearnSpace.EntityFrameworkCore;
using QuickLearnSpace.Migrator.DependencyInjection;

namespace QuickLearnSpace.Migrator
{
    [DependsOn(typeof(QuickLearnSpaceEntityFrameworkModule))]
    public class QuickLearnSpaceMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QuickLearnSpaceMigratorModule(QuickLearnSpaceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(QuickLearnSpaceMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                QuickLearnSpaceConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(QuickLearnSpaceMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
