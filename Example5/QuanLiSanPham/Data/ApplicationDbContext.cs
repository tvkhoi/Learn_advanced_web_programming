using Microsoft.EntityFrameworkCore;
using QuanLiSanPham.Models;
using QuanLiSanPham.ViewModels;

namespace QuanLiSanPham.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }
        public DbSet<SanPhamViewModel> sanPhams { get; set; }
        public DbSet<SanPhamViewModel> danhMucs { get; set; }
    }
}
