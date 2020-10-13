using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class Empleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeUserId",
                table: "ServiceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployedById",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeUser_Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_EmployeeUserId",
                table: "ServiceModel",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployedById",
                table: "AspNetUsers",
                column: "EmployedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_EmployedById",
                table: "AspNetUsers",
                column: "EmployedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_AspNetUsers_EmployeeUserId",
                table: "ServiceModel",
                column: "EmployeeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_EmployedById",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_AspNetUsers_EmployeeUserId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_EmployeeUserId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeUserId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "EmployedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeUser_Name",
                table: "AspNetUsers");
        }
    }
}
