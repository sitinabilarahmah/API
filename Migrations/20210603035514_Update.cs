using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "id",
                table: "TB_T_AccountRole");

            migrationBuilder.RenameColumn(
                name: "AccountNIK",
                table: "TB_T_AccountRole",
                newName: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                columns: new[] { "NIK", "Roleid" });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_NIK",
                table: "TB_T_AccountRole",
                column: "NIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_NIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.RenameColumn(
                name: "NIK",
                table: "TB_T_AccountRole",
                newName: "AccountNIK");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
