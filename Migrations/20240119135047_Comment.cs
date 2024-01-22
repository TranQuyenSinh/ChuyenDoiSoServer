using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuyenDoiSoServer.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    TinTucId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanChaId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinhLuan_BinhLuan_BinhLuanChaId",
                        column: x => x.BinhLuanChaId,
                        principalTable: "BinhLuan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BinhLuan_TinTuc_TinTucId",
                        column: x => x.TinTucId,
                        principalTable: "TinTuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuan_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_BinhLuanChaId",
                table: "BinhLuan",
                column: "BinhLuanChaId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_TinTucId",
                table: "BinhLuan",
                column: "TinTucId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_UserId",
                table: "BinhLuan",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");
        }
    }
}
