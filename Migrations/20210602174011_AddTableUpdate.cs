using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Account_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Role_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Role");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Role_AccountRoleid",
                table: "TB_M_Role");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Account_AccountRoleid",
                table: "TB_M_Account");

            migrationBuilder.DropColumn(
                name: "AccountRoleid",
                table: "TB_M_Role");

            migrationBuilder.DropColumn(
                name: "AccountRoleid",
                table: "TB_M_Account");

            migrationBuilder.AddColumn<int>(
                name: "AccountNIK",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_Roleid",
                table: "TB_T_AccountRole",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_Roleid",
                table: "TB_T_AccountRole",
                column: "Roleid",
                principalTable: "TB_M_Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Role_Roleid",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_AccountRole_Roleid",
                table: "TB_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.AddColumn<int>(
                name: "AccountRoleid",
                table: "TB_M_Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountRoleid",
                table: "TB_M_Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Role_AccountRoleid",
                table: "TB_M_Role",
                column: "AccountRoleid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Account_AccountRoleid",
                table: "TB_M_Account",
                column: "AccountRoleid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Account_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Account",
                column: "AccountRoleid",
                principalTable: "TB_T_AccountRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Role_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Role",
                column: "AccountRoleid",
                principalTable: "TB_T_AccountRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
