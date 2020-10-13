using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class quotationFkToTaskModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Quotation_QuotationFk",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_QuotationFk",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "QuotationFk",
                table: "Task");

            migrationBuilder.AddColumn<Guid>(
                name: "QuotationId",
                table: "Task",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Task_QuotationId",
                table: "Task",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Quotation_QuotationId",
                table: "Task",
                column: "QuotationId",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Quotation_QuotationId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_QuotationId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Task");

            migrationBuilder.AddColumn<Guid>(
                name: "QuotationFk",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Task_QuotationFk",
                table: "Task",
                column: "QuotationFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Quotation_QuotationFk",
                table: "Task",
                column: "QuotationFk",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
