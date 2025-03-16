using Microsoft.AspNetCore.Mvc;
using QuanLiSanPham.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuanLiSanPham.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public SanPhamController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            var danhSachSanPham = await _todoItemService.GetAllAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LayDanhSachSanPham()
        {
            var danhSachSanPham = await _todoItemService.GetAllAsync();
            return Json(danhSachSanPham);
        }
    }
}
