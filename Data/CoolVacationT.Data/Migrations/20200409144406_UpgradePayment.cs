using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolVacationT.Data.Migrations
{
    public partial class UpgradePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StringFileCloud",
                table: "Payments",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringFileCloud",
                table: "Payments");
        }
    }
}
