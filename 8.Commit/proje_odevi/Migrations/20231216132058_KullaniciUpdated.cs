using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proje_odevi.Migrations
{
    public partial class KullaniciUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Kullanıcılar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Kullanici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Kullanıcılar");
        }
    }
}
