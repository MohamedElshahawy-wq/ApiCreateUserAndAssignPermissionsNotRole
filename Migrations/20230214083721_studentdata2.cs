using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCreateUserAndAssignPermissionsNotRole.Migrations
{
    public partial class studentdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsData",
                table: "StudentsData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentsData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentsData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsData",
                table: "StudentsData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsData",
                table: "StudentsData");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentsData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentsData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsData",
                table: "StudentsData",
                column: "Name");
        }
    }
}
