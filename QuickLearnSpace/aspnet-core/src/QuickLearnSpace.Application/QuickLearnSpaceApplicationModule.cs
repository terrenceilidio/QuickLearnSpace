using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickLearnSpace.Authorization;

namespace QuickLearnSpace
{
    [DependsOn(
        typeof(QuickLearnSpaceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QuickLearnSpaceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QuickLearnSpaceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QuickLearnSpaceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
