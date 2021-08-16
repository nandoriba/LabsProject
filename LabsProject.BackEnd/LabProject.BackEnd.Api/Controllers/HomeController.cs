using Microsoft.AspNetCore.Mvc;

namespace LabsProject.BackEnd.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
