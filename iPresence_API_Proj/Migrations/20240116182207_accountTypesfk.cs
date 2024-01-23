using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iPresence_API_Proj.Migrations
{
    public partial class accountTypesfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AccountTypeId",
                table: "Teacher",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AccountTypeId",
                table: "Students",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AccountTypeId",
                table: "Admin",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AccountTypes_AccountTypeId",
                table: "Admin",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "AccountTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AccountTypes_AccountTypeId",
                table: "Students",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "AccountTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_AccountTypes_AccountTypeId",
                table: "Teacher",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "AccountTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AccountTypes_AccountTypeId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AccountTypes_AccountTypeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_AccountTypes_AccountTypeId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_AccountTypeId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Students_AccountTypeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AccountTypeId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Admin");
        }
    }
}
