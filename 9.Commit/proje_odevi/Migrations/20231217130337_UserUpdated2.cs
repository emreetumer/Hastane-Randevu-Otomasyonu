using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proje_odevi.Migrations
{
    public partial class UserUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilResmiDosyaAdi",
                table: "Kullanıcılar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                defaultValue:"noimage.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilResmiDosyaAdi",
                table: "Kullanıcılar");
        }
    }
}
