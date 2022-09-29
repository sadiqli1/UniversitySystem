using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Persistence.Context.Migrations
{
    public partial class UpdatePointListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DVM",
                table: "PointLists",
                newName: "AttendancePoint");

            migrationBuilder.AlterColumn<byte>(
                name: "ReExam",
                table: "PointLists",
                type: "tinyint",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<byte>(
                name: "AdditionalExam",
                table: "PointLists",
                type: "tinyint",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "AttendanceCount",
                table: "PointLists",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendanceCount",
                table: "PointLists");

            migrationBuilder.RenameColumn(
                name: "AttendancePoint",
                table: "PointLists",
                newName: "DVM");

            migrationBuilder.AlterColumn<byte>(
                name: "ReExam",
                table: "PointLists",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "AdditionalExam",
                table: "PointLists",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
