using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace proje_odevi.Controllers
{
    [Authorize(Roles ="Admin" + "admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
