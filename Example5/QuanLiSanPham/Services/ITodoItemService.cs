using QuanLiSanPham.Models;
using QuanLiSanPham.ViewModels;

namespace QuanLiSanPham.Services
{
    public interface ITodoItemService
    {
        // Thêm sản phẩm mới
        Task<SanPhamViewModel> CreateAsync(SanPhamViewModel sanPham);

        // Lấy thông tin sản phẩm theo Id
        Task<SanPhamViewModel> GetByIdAsync(int id);

        // Lấy danh sách tất cả sản phẩm
        Task<IEnumerable<SanPhamViewModel>> GetAllAsync();

        // Cập nhật thông tin sản phẩm
        Task<bool> UpdateAsync(SanPhamViewModel sanPham);

        // Xóa sản phẩm theo Id
        Task<bool> DeleteAsync(int id);
    }
}
