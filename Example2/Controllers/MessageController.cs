using Example2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example2.Controllers
{
    public class MessageController : Controller
    {
        // Dữ liệu hardcoded
        private static List<Message> messages = new List<Message>
        {
            new Message { Id = 1, Content = "Hello, world!", SenderId = 1, TopicId = 1, CreatedAt = DateTime.Now },
            new Message { Id = 2, Content = "Tech trends 2025", SenderId = 2, TopicId = 2, CreatedAt = DateTime.Now }
        };

        // GET: Message
        public IActionResult Index()
        {
            return View(messages);
        }

        // GET: Message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Content,SenderId,TopicId")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.Id = messages.Count + 1; // Tạo ID mới cho message
                message.CreatedAt = DateTime.Now;
                messages.Add(message);
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Message/Delete/5
        public IActionResult Delete(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                messages.Remove(message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
