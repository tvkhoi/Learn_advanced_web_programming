using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiSanPham.Models
{
    [Table("tblDanhMuc")]
    public class DanhMuc
    {
        [Column("PK_iMaDanhMuc",TypeName ="int")]
        public int Id { get; set; }

        [Column("sTen",TypeName ="nvarchar(250)")]
        public string Ten {  get; set; }

        [Column("sMoTa",TypeName ="nvarchar(1000)")]
        public string MoTa { get; set; }
        [Column("FK_iSanPham")]
        public ICollection<SanPham> sanPhams { get; set; }
    }
}
