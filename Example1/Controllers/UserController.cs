using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
{
    public class UserController:Controller
    {   
        // Dữ liệu mẫu để hiển thị danh sách người dùng
        private static List<string> users = new List<string> { "Khởi", "Hoàng", "Vương" };
        // ActionMethod Index
        public IActionResult Index()
        {
            return View(users); 
        }

        // Thêm ActionMethod khác để quản lý người dùng (Create, Edit, Delete)
        public IActionResult Create(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ViewBag.ErrorMessage = "Tên người dùng không được để trống.";
                return View(); 
            }

            if (users.Any(u => string.Equals(u, userName, StringComparison.OrdinalIgnoreCase)))
            {
                ViewBag.ErrorMessage = "Tên người dùng đã tồn tại. Vui lòng chọn tên khác.";
                return View(); 
            }

            // Thêm người dùng vào danh sách nếu không trùng
            users.Add(userName);
            return RedirectToAction("Index"); // Chuyển về trang Index 
        }
        public IActionResult Edit(string oldUserName, string newUserName)
        {
            if (string.IsNullOrEmpty(newUserName))
            {
                ViewBag.ErrorMessage = "Tên người dùng mới không được để trống.";
                ViewBag.UserName = oldUserName;  // Truyền tên người dùng cũ vào View
                return View();
            }

            // Kiểm tra xem tên người dùng mới đã tồn tại chưa
            if (users.Any(u => string.Equals(u, newUserName, StringComparison.OrdinalIgnoreCase)))
            {
                ViewBag.ErrorMessage = "Tên người dùng mới đã tồn tại.";
                ViewBag.serName = oldUserName;
                return View();
            }

            // Tìm người dùng trong danh sách và cập nhật
            var userIndex = users.FindIndex(u => string.Equals(u, oldUserName, StringComparison.OrdinalIgnoreCase));
            if (userIndex != -1)
            {
                users[userIndex] = newUserName; // Cập nhật tên người dùng
                TempData["SuccessMessage"] = $"Cập nhật thành công: {oldUserName} -> {newUserName}";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ViewBag.ErrorMessage = "Tên người dùng không được cung cấp.";
                return RedirectToAction("Index");
            }

            // Kiểm tra xem người dùng có tồn tại không
            var userToRemove = users.Find(u => string.Equals(u, userName, StringComparison.OrdinalIgnoreCase));

            if (userToRemove == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy người dùng.";
                return RedirectToAction("Index");
            }

            // Xóa người dùng nếu tìm thấy
            users.Remove(userToRemove);

            TempData["SuccessMessage"] = $"Đã xóa người dùng: {userName}";
            return RedirectToAction("Index");
        }
    }
}
