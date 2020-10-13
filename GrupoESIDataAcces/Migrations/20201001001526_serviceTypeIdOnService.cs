using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class serviceTypeIdOnService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_ServiceType_serviceTypeId",
                table: "ServiceModel");

            migrationBuilder.RenameColumn(
                name: "serviceTypeId",
                table: "ServiceModel",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceModel_serviceTypeId",
                table: "ServiceModel",
                newName: "IX_ServiceModel_ServiceTypeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceTypeId",
                table: "ServiceModel",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_ServiceType_ServiceTypeId",
                table: "ServiceModel",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_ServiceType_ServiceTypeId",
                table: "ServiceModel");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceModel",
                newName: "serviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceModel_ServiceTypeId",
                table: "ServiceModel",
                newName: "IX_ServiceModel_serviceTypeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "serviceTypeId",
                table: "ServiceModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_ServiceType_serviceTypeId",
                table: "ServiceModel",
                column: "serviceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
