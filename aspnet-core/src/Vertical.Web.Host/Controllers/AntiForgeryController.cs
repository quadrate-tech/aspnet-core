using Abp.Web.Security.AntiForgery;
using Microsoft.AspNetCore.Antiforgery;
using Vertical.Controllers;

namespace Vertical.Web.Controllers
{
    public class AntiForgeryController : VerticalControllerBase
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(
            IAntiforgery antiforgery,
            IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
