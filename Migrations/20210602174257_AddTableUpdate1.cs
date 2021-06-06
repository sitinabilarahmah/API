using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTableUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NIK",
                table: "TB_T_AccountRole",
                newName: "AccoountNIK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccoountNIK",
                table: "TB_T_AccountRole",
                newName: "NIK");
        }
    }
}
