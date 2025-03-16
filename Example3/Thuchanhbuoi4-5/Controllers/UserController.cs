using Microsoft.AspNetCore.Mvc;
using Thuchanhbuoi4_5.Mappers;
using Thuchanhbuoi4_5.Services;
using Thuchanhbuoi4_5.ViewModels;

namespace Thuchanhbuoi4_5.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            var userViewModels = users.Select(u => UserMapper.ToViewModel(u)).ToList();
            return View(userViewModels);
        }
    }

}
