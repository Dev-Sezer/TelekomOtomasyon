using Microsoft.AspNetCore.Mvc;

namespace TelekomWebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
