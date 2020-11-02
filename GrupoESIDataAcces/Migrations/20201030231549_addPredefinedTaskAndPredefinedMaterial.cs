using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class addPredefinedTaskAndPredefinedMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PredefinedTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    CostHandLabor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredefinedTask_ServiceModel_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PredefinedTaskId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredefinedMaterial_PredefinedTask_PredefinedTaskId",
                        column: x => x.PredefinedTaskId,
                        principalTable: "PredefinedTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedMaterial_PredefinedTaskId",
                table: "PredefinedMaterial",
                column: "PredefinedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedTask_ServiceId",
                table: "PredefinedTask",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredefinedMaterial");

            migrationBuilder.DropTable(
                name: "PredefinedTask");
        }
    }
}
