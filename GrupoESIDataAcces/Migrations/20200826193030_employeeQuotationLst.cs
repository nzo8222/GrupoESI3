using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class employeeQuotationLst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeUserId",
                table: "Quotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_EmployeeUserId",
                table: "Quotation",
                column: "EmployeeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_AspNetUsers_EmployeeUserId",
                table: "Quotation",
                column: "EmployeeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_AspNetUsers_EmployeeUserId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_EmployeeUserId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "EmployeeUserId",
                table: "Quotation");
        }
    }
}
