using Example2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example2.Controllers
{
    public class UserTopicController : Controller
    {
        // Dữ liệu hardcoded
        private static List<UserTopic> userTopics = new List<UserTopic>
        {
            new UserTopic { UserId = 1, TopicId = 1, Role = "Admin", JoinedAt = DateTime.Now },
            new UserTopic { UserId = 2, TopicId = 2, Role = "Member", JoinedAt = DateTime.Now }
        };

        // GET: UserTopic
        public IActionResult Index()
        {
            return View(userTopics);
        }

        // GET: UserTopic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTopic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,TopicId,Role")] UserTopic userTopic)
        {
            if (ModelState.IsValid)
            {
                userTopic.JoinedAt = DateTime.Now;
                userTopics.Add(userTopic);
                return RedirectToAction(nameof(Index));
            }
            return View(userTopic);
        }

        // GET: UserTopic/Delete/5
        public IActionResult Delete(int userId, int topicId)
        {
            var userTopic = userTopics.FirstOrDefault(ut => ut.UserId == userId && ut.TopicId == topicId);
            if (userTopic == null)
            {
                return NotFound();
            }
            return View(userTopic);
        }

        // POST: UserTopic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int userId, int topicId)
        {
            var userTopic = userTopics.FirstOrDefault(ut => ut.UserId == userId && ut.TopicId == topicId);
            if (userTopic != null)
            {
                userTopics.Remove(userTopic);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
