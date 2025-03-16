using Example2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example2.Controllers
{
    public class UserController : Controller
    {
        // Dữ liệu hardcoded
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "john_doe", PasswordHash = "hashedpassword123", Email = "john@example.com", FullName = "John Doe", Role = "Admin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new User { Id = 2, Username = "jane_smith", PasswordHash = "hashedpassword456", Email = "jane@example.com", FullName = "Jane Smith", Role = "User", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        // GET: User
        public IActionResult Index()
        {
            return View(users);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Username,PasswordHash,Email,FullName,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = users.Count + 1; // Tạo ID mới cho user
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Username,PasswordHash,Email,FullName,Role,CreatedAt")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Username = user.Username;
                    existingUser.PasswordHash = user.PasswordHash;
                    existingUser.Email = user.Email;
                    existingUser.FullName = user.FullName;
                    existingUser.Role = user.Role;
                    existingUser.UpdatedAt = DateTime.Now;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
