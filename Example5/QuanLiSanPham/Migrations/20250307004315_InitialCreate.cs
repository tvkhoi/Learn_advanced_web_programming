using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiSanPham.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "danhMucs",
                columns: table => new
                {
                    PK_iMaDanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTen = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    sMoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhMucs", x => x.PK_iMaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    PK_iMaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTen = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    fGia = table.Column<float>(type: "real", nullable: false),
                    sMoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    danhMucId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.PK_iMaSanPham);
                    table.ForeignKey(
                        name: "FK_sanPhams_danhMucs_danhMucId",
                        column: x => x.danhMucId,
                        principalTable: "danhMucs",
                        principalColumn: "PK_iMaDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_danhMucId",
                table: "sanPhams",
                column: "danhMucId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "danhMucs");
        }
    }
}
