using Microsoft.AspNetCore.Mvc;

namespace ModuleA.Controllers
{
    [Area("ModuleA")]
    public class HomeController: Controller
    {
        public IActionResult Index() => Ok("ModuleA");
    }
}