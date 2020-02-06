using Microsoft.AspNetCore.Mvc;
using Vertical.Controllers;

namespace Vertical.Web.Controllers
{
    public class HomeController : VerticalControllerBase
    {
        public IActionResult Index() => Redirect("/swagger");
    }
}
