using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiSanPham.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sanPhams_danhMucs_danhMucId",
                table: "sanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sanPhams",
                table: "sanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_danhMucs",
                table: "danhMucs");

            migrationBuilder.RenameTable(
                name: "sanPhams",
                newName: "tblSanPham");

            migrationBuilder.RenameTable(
                name: "danhMucs",
                newName: "tblDanhMuc");

            migrationBuilder.RenameIndex(
                name: "IX_sanPhams_danhMucId",
                table: "tblSanPham",
                newName: "IX_tblSanPham_danhMucId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblSanPham",
                table: "tblSanPham",
                column: "PK_iMaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDanhMuc",
                table: "tblDanhMuc",
                column: "PK_iMaDanhMuc");

            migrationBuilder.AddForeignKey(
                name: "FK_tblSanPham_tblDanhMuc_danhMucId",
                table: "tblSanPham",
                column: "danhMucId",
                principalTable: "tblDanhMuc",
                principalColumn: "PK_iMaDanhMuc",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSanPham_tblDanhMuc_danhMucId",
                table: "tblSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblSanPham",
                table: "tblSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDanhMuc",
                table: "tblDanhMuc");

            migrationBuilder.RenameTable(
                name: "tblSanPham",
                newName: "sanPhams");

            migrationBuilder.RenameTable(
                name: "tblDanhMuc",
                newName: "danhMucs");

            migrationBuilder.RenameIndex(
                name: "IX_tblSanPham_danhMucId",
                table: "sanPhams",
                newName: "IX_sanPhams_danhMucId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sanPhams",
                table: "sanPhams",
                column: "PK_iMaSanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_danhMucs",
                table: "danhMucs",
                column: "PK_iMaDanhMuc");

            migrationBuilder.AddForeignKey(
                name: "FK_sanPhams_danhMucs_danhMucId",
                table: "sanPhams",
                column: "danhMucId",
                principalTable: "danhMucs",
                principalColumn: "PK_iMaDanhMuc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
