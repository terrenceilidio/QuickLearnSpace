using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuickLearnSpace.Configuration;
using QuickLearnSpace.Web;

namespace QuickLearnSpace.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class QuickLearnSpaceDbContextFactory : IDesignTimeDbContextFactory<QuickLearnSpaceDbContext>
    {
        public QuickLearnSpaceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QuickLearnSpaceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            QuickLearnSpaceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(QuickLearnSpaceConsts.ConnectionStringName));

            return new QuickLearnSpaceDbContext(builder.Options);
        }
    }
}
