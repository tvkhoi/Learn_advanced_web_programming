using Microsoft.AspNetCore.Mvc;
using ThucHanhBuoi6.Models;

namespace ThucHanhBuoi6.Controllers
{
    public class ProductController : Controller
    {
        private static List<ProductViewModel> products = new List<ProductViewModel>();
        public IActionResult Index()
        {
            return View();
        }

        // Action lấy danh sách sản phẩm
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Json(products); // Trả về danh sách sản phẩm dạng JSON
        }

        // Action thêm sản phẩm
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1; // Tạo ID tự động
                products.Add(model);
                return Json(model); // Trả về sản phẩm mới sau khi thêm
            }
            return BadRequest(ModelState);
        }

        // Action cập nhật sản phẩm
        [HttpPost]
        public IActionResult UpdateProduct([FromBody] ProductViewModel model)
        {
            var product = products.FirstOrDefault(p => p.Id == model.Id);
            if (product != null && ModelState.IsValid)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                return Json(product); // Trả về sản phẩm sau khi cập nhật
            }
            return BadRequest("Sản phẩm không tồn tại hoặc dữ liệu không hợp lệ.");
        }

        // Action xóa sản phẩm
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                return Json(id); // Trả về ID của sản phẩm đã xóa
            }
            return BadRequest("Sản phẩm không tồn tại.");
        }

    }

}
