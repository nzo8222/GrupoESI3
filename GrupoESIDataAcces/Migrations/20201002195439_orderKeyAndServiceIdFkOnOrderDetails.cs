using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class orderKeyAndServiceIdFkOnOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ServiceModel_ServiceID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "OrderDetails",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ServiceID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ServiceId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ServiceModel_ServiceId",
                table: "OrderDetails",
                column: "ServiceId",
                principalTable: "ServiceModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ServiceModel_ServiceId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderDetails",
                newName: "ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ServiceId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ServiceID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceID",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ServiceModel_ServiceID",
                table: "OrderDetails",
                column: "ServiceID",
                principalTable: "ServiceModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
