using Abp.Authorization;
using QuickLearnSpace.Authorization.Roles;
using QuickLearnSpace.Authorization.Users;

namespace QuickLearnSpace.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
