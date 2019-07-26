using Microsoft.AspNetCore.Antiforgery;
using QuickLearnSpace.Controllers;

namespace QuickLearnSpace.Web.Host.Controllers
{
    public class AntiForgeryController : QuickLearnSpaceControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
