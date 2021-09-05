using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Data.Migrations
{
    public partial class AddDescriptionAndRenamingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Tasks",
                newName: "Importance");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Importance",
                table: "Tasks",
                newName: "Level");
        }
    }
}
