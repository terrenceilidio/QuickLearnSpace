using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QuickLearnSpace.Controllers
{
    public abstract class QuickLearnSpaceControllerBase: AbpController
    {
        protected QuickLearnSpaceControllerBase()
        {
            LocalizationSourceName = QuickLearnSpaceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
