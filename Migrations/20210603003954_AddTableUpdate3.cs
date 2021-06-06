using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTableUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "TB_M_Role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TB_M_Role",
                newName: "Rolename");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_M_Role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Rolename",
                table: "TB_M_Role",
                newName: "name");
        }
    }
}
