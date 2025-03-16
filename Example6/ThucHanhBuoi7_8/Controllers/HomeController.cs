using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHanhBuoi7_8.Models;

namespace ThucHanhBuoi7_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int soLanTruyCap = 1;
            if (Request.Cookies.ContainsKey("SoLanTruyCap"))
            {
                soLanTruyCap = int.Parse(Request.Cookies["SoLanTruyCap"]) + 1;
            }

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // Cookie tồn tại trong 30 ngày
            };
            Response.Cookies.Append("SoLanTruyCap", soLanTruyCap.ToString(), options);

            ViewBag.SoLanTruyCap = soLanTruyCap;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
