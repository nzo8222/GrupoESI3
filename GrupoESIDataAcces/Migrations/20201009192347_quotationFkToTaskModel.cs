using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class quotationFkToTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Quotation_QuotationModelId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_QuotationModelId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "QuotationModelId",
                table: "Task");

            migrationBuilder.AddColumn<Guid>(
                name: "QuotationFk",
                table: "Task",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "QuotationModelId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_QuotationModelId",
                table: "Task",
                column: "QuotationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Quotation_QuotationModelId",
                table: "Task",
                column: "QuotationModelId",
                principalTable: "Quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
