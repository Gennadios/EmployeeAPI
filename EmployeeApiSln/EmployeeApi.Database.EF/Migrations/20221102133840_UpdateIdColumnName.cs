using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApi.Database.EF.Migrations
{
    public partial class UpdateIdColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");
        }
    }
}
