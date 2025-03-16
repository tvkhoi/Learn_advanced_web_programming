using Example2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example2.Controllers
{
    public class TopicController : Controller
    {
        // Dữ liệu hardcoded
        private static List<Topic> topics = new List<Topic>
        {
            new Topic { Id = 1, Title = "General Discussion", Description = "A place for general conversations.", CreatedBy = 1, IsPublic = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Topic { Id = 2, Title = "Tech Talk", Description = "Discussion on latest tech.", CreatedBy = 2, IsPublic = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        // GET: Topic
        public IActionResult Index()
        {
            return View(topics);
        }

        // GET: Topic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Description,CreatedBy")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.Id = topics.Count + 1; // Tạo ID mới cho topic
                topic.CreatedAt = DateTime.Now;
                topic.UpdatedAt = DateTime.Now;
                topics.Add(topic);
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topic/Edit/5
        public IActionResult Edit(int id)
        {
            var topic = topics.FirstOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,CreatedBy,CreatedAt")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTopic = topics.FirstOrDefault(t => t.Id == id);
                if (existingTopic != null)
                {
                    existingTopic.Title = topic.Title;
                    existingTopic.Description = topic.Description;
                    existingTopic.CreatedBy = topic.CreatedBy;
                    existingTopic.UpdatedAt = DateTime.Now;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topic/Delete/5
        public IActionResult Delete(int id)
        {
            var topic = topics.FirstOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var topic = topics.FirstOrDefault(t => t.Id == id);
            if (topic != null)
            {
                topics.Remove(topic);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
