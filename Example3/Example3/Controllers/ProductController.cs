using Microsoft.AspNetCore.Mvc;

namespace Example3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Product Management";
            ViewBag.Content = "This is the product Management dashboard";
            return View();
        }
    }
}
