using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using QuickLearnSpace.EntityFrameworkCore.Seed;

namespace QuickLearnSpace.EntityFrameworkCore
{
    [DependsOn(
        typeof(QuickLearnSpaceCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class QuickLearnSpaceEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<QuickLearnSpaceDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        QuickLearnSpaceDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        QuickLearnSpaceDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuickLearnSpaceEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
