using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoESIDataAccess.Migrations
{
    public partial class pics1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "CostHandLaborReal",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CostReal",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "DurationReal",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_TaskModelId",
                table: "Pictures",
                newName: "IX_Pictures_TaskModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Task_TaskModelId",
                table: "Pictures",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Task_TaskModelId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_TaskModelId",
                table: "Picture",
                newName: "IX_Picture_TaskModelId");

            migrationBuilder.AddColumn<double>(
                name: "CostHandLaborReal",
                table: "Task",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CostReal",
                table: "Task",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DurationReal",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Task_TaskModelId",
                table: "Picture",
                column: "TaskModelId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
