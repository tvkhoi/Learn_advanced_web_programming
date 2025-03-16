using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace QuanLiSanPham.Models
{
    [Table("tblSanPham")]
    public class SanPham
    {
        [Column("PK_iMaSanPham",TypeName ="int")]
        public int Id { get; set; }

        [Column("sTen",TypeName ="nvarchar(250)")]
        public string Ten {  get; set; }

        [Column("fGia")]
        public float Gia { get; set; }

        [Column("sMoTa",TypeName ="nvarchar(1000)")]
        public string MoTa { get; set; }

        [Column("FK_iDanhMuc")]
        public DanhMuc danhMuc { get; set; }
    }
}
