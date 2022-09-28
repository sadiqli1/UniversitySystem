using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Persistence.Context.Migrations
{
    public partial class UpdateAttendancesAndLessonSchedulesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "LessonScheduleId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LessonScheduleId",
                table: "Attendances",
                column: "LessonScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_LessonSchedules_LessonScheduleId",
                table: "Attendances",
                column: "LessonScheduleId",
                principalTable: "LessonSchedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_LessonSchedules_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LessonScheduleId",
                table: "Attendances");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
