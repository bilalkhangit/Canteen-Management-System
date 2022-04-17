using Microsoft.EntityFrameworkCore.Migrations;

namespace Canteen_Management_System.Infrastructure.Migrations
{
    public partial class brandEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Brands");
        }
    }
}
