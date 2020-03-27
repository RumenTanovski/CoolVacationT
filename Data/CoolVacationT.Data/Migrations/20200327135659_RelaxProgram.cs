using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolVacationT.Data.Migrations
{
    public partial class RelaxProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "FeedBacks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RelaxPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    EcoTrail = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    SwimmingPool = table.Column<string>(nullable: true),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaxPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelaxPrograms_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelaxPrograms_IsDeleted",
                table: "RelaxPrograms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RelaxPrograms_ReservationId",
                table: "RelaxPrograms",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelaxPrograms");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "FeedBacks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
