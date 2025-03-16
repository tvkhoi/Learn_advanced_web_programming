using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // Phương thức xử lý đăng nhập
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Giả sử đã xác thực người dùng thành công
        // Lưu trữ thông tin người dùng vào Session
        HttpContext.Session.SetString("Username", username);
        HttpContext.Session.SetInt32("LoginCount", 1);

        return RedirectToAction("Dashboard");
    }

    // Phương thức hiển thị bảng điều khiển sau khi đăng nhập
    public IActionResult Dashboard()
    {
        // Truy xuất thông tin từ Session
        var username = HttpContext.Session.GetString("Username");
        var loginCount = HttpContext.Session.GetInt32("LoginCount") ?? 0;

        if (username == null)
        {
            // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login");
        }

        // Tăng số lần đăng nhập và cập nhật lại Session
        loginCount++;
        HttpContext.Session.SetInt32("LoginCount", loginCount);

        // Truyền dữ liệu đến View
        ViewBag.Username = username;
        ViewBag.LoginCount = loginCount;

        return View();
    }

    // Phương thức xử lý đăng xuất
    public IActionResult Logout()
    {
        // Xóa tất cả dữ liệu trong Session
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    // Phương thức hiển thị trang đăng nhập
    public IActionResult Login()
    {
        return View();
    }
}
