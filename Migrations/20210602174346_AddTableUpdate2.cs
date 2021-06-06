using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "AccoountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNIK",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNIK",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccoountNIK",
                table: "TB_T_AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                table: "TB_T_AccountRole",
                column: "AccountNIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
