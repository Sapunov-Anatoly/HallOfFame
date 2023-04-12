using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallOfFame.Migrations
{
    /// <inheritdoc />
    public partial class _3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Skills",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Skill_name",
                table: "Skills",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_PersonId",
                table: "Skills",
                newName: "IX_Skills_PersonID");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Persons_PersonID",
                table: "Skills",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Persons_PersonID",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Skills",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Skills",
                newName: "Skill_name");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_PersonID",
                table: "Skills",
                newName: "IX_Skills_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Level",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
