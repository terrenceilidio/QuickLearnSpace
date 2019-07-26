using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickLearnSpace.Configuration;

namespace QuickLearnSpace.Web.Host.Startup
{
    [DependsOn(
       typeof(QuickLearnSpaceWebCoreModule))]
    public class QuickLearnSpaceWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QuickLearnSpaceWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuickLearnSpaceWebHostModule).GetAssembly());
        }
    }
}
