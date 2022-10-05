using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Persistence.Context.Migrations
{
    public partial class updategrouptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_LessonSchedules_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonSchedules_Lessons_LessonId",
                table: "LessonSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LessonScheduleId",
                table: "Attendances",
                column: "LessonScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_LessonSchedules_LessonScheduleId",
                table: "Attendances",
                column: "LessonScheduleId",
                principalTable: "LessonSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonSchedules_Lessons_LessonId",
                table: "LessonSchedules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_LessonSchedules_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonSchedules_Lessons_LessonId",
                table: "LessonSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_LessonScheduleId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonSchedules_Lessons_LessonId",
                table: "LessonSchedules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
