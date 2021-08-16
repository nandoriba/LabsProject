using Microsoft.AspNetCore.Mvc;

namespace LabsProject.BackEnd.API.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
