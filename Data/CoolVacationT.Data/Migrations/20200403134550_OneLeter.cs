using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolVacationT.Data.Migrations
{
    public partial class OneLeter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_PaymnetId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Periods_PeriodId1",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RelaxPrograms_RelaxProgramId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PaymnetId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PeriodId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RelaxProgramId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymnetId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PeriodId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RelaxProgramId1",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "RelaxProgramId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PeriodId",
                table: "Reservations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RelaxProgramId",
                table: "Reservations",
                column: "RelaxProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_PaymentId",
                table: "Reservations",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Periods_PeriodId",
                table: "Reservations",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RelaxPrograms_RelaxProgramId",
                table: "Reservations",
                column: "RelaxProgramId",
                principalTable: "RelaxPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_PaymentId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Periods_PeriodId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RelaxPrograms_RelaxProgramId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PeriodId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RelaxProgramId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "RelaxProgramId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PeriodId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymnetId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelaxProgramId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymnetId",
                table: "Reservations",
                column: "PaymnetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PeriodId1",
                table: "Reservations",
                column: "PeriodId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RelaxProgramId1",
                table: "Reservations",
                column: "RelaxProgramId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_PaymnetId",
                table: "Reservations",
                column: "PaymnetId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Periods_PeriodId1",
                table: "Reservations",
                column: "PeriodId1",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RelaxPrograms_RelaxProgramId1",
                table: "Reservations",
                column: "RelaxProgramId1",
                principalTable: "RelaxPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
