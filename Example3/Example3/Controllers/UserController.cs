using Microsoft.AspNetCore.Mvc;

namespace Example3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "User Management";
            ViewBag.Content = "This is the user management dashboard";
            return View();
        }
    }
}
