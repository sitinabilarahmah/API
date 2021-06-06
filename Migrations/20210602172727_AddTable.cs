using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRoleid",
                table: "TB_M_Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_T_AccountRole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Roleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_AccountRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountRoleid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_M_Role_TB_T_AccountRole_AccountRoleid",
                        column: x => x.AccountRoleid,
                        principalTable: "TB_T_AccountRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Account_AccountRoleid",
                table: "TB_M_Account",
                column: "AccountRoleid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Role_AccountRoleid",
                table: "TB_M_Role",
                column: "AccountRoleid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Account_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Account",
                column: "AccountRoleid",
                principalTable: "TB_T_AccountRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Account_TB_T_AccountRole_AccountRoleid",
                table: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Account_AccountRoleid",
                table: "TB_M_Account");

            migrationBuilder.DropColumn(
                name: "AccountRoleid",
                table: "TB_M_Account");
        }
    }
}
