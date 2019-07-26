using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QuickLearnSpace.Authorization.Roles;
using QuickLearnSpace.Authorization.Users;
using QuickLearnSpace.MultiTenancy;

namespace QuickLearnSpace.EntityFrameworkCore
{
    public class QuickLearnSpaceDbContext : AbpZeroDbContext<Tenant, Role, User, QuickLearnSpaceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public QuickLearnSpaceDbContext(DbContextOptions<QuickLearnSpaceDbContext> options)
            : base(options)
        {
        }
    }
}
