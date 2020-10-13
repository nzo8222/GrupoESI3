using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class DatosALosModelosParaFechasDeProveedorYEvidencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CostHandLaborReal",
                table: "Task",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CostReal",
                table: "Task",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DurationReal",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaGuardadoCotizacion",
                table: "Quotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLlegadaProveedor",
                table: "Quotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeSubida",
                table: "Picture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Picture",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostHandLaborReal",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CostReal",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "DurationReal",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "FechaGuardadoCotizacion",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "FechaLlegadaProveedor",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "FechaDeSubida",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Picture");
        }
    }
}
