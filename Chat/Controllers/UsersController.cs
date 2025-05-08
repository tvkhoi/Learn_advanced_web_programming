using Chat.Data;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationDbContext _db;
		public UsersController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<UserDomainModel> objUserList = _db.Users.ToList();
			return View(objUserList);
		}
	}
}
