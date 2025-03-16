using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        // Kiểm tra xem người dùng đã đăng nhập chưa
        var username = HttpContext.Session.GetString("Username");
        if (username == null)
        {
            // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login", "Account");
        }

        // Thực hiện các logic khác
        return View();
    }
}
