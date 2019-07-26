using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QuickLearnSpace.EntityFrameworkCore
{
    public static class QuickLearnSpaceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QuickLearnSpaceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QuickLearnSpaceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
