using Microsoft.EntityFrameworkCore;
using QuanLiSanPham.Data;
using QuanLiSanPham.Models;
using QuanLiSanPham.ViewModels;

namespace QuanLiSanPham.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        public TodoItemService(ApplicationDbContext context)
        {
            _context =  context;
        }
        public async Task<SanPhamViewModel> CreateAsync(SanPhamViewModel sanPham)
        {
            _context.sanPhams.Add(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sanPham = await _context.sanPhams.FindAsync(id);
            if(sanPham == null)
            {
                return false;
            }
            _context.sanPhams.Remove(sanPham);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.sanPhams.ToListAsync();
        }

        public async Task<SanPham> GetByIdAsync(int id)
        {
            return await _context.sanPhams.Include(x => x.Id).FirstOrDefaultAsync(sp
                => sp.Id == id);
        }

        public Task<bool> UpdateAsync(SanPham sanPham)
        {
            throw new NotImplementedException();
        }
    }
}
