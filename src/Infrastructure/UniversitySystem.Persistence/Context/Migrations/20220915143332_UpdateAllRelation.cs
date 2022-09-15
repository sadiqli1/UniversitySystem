using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Persistence.Context.Migrations
{
    public partial class UpdateAllRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Transcripts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OnlineServiceId",
                table: "Transcripts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Transcripts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OnlineServiceId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTypeId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "PointLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "PointLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "ParticipationLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ParticipationLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Librarians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Librarians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Journals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Journals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "EducationDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_LanguageId",
                table: "Transcripts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_OnlineServiceId",
                table: "Transcripts",
                column: "OnlineServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentId",
                table: "Transcripts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DutyId",
                table: "Teachers",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SectionId",
                table: "Teachers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DutyId",
                table: "Students",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_FacultyId",
                table: "Specializations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SectionId",
                table: "Specializations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SectorId",
                table: "Specializations",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LibraryId",
                table: "Rooms",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_References_LanguageId",
                table: "References",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_References_OnlineServiceId",
                table: "References",
                column: "OnlineServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ReferenceTypeId",
                table: "References",
                column: "ReferenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_References_StudentId",
                table: "References",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PointLists_LessonId",
                table: "PointLists",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_PointLists_StudentId",
                table: "PointLists",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationLists_LessonId",
                table: "ParticipationLists",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationLists_StudentId",
                table: "ParticipationLists",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_DutyId",
                table: "Librarians",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_LibraryId",
                table: "Librarians",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_LanguageId",
                table: "Journals",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_RoomId",
                table: "Journals",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecializationId",
                table: "Groups",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationDepartments_DutyId",
                table: "EducationDepartments",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_RoomId",
                table: "Books",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_DutyId",
                table: "Announcements",
                column: "DutyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Duties_DutyId",
                table: "Announcements",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Rooms_RoomId",
                table: "Books",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationDepartments_Duties_DutyId",
                table: "EducationDepartments",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specializations_SpecializationId",
                table: "Groups",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Languages_LanguageId",
                table: "Journals",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Rooms_RoomId",
                table: "Journals",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Sections_SectionId",
                table: "Lessons",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Duties_DutyId",
                table: "Librarians",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationLists_Lessons_LessonId",
                table: "ParticipationLists",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationLists_Students_StudentId",
                table: "ParticipationLists",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointLists_Lessons_LessonId",
                table: "PointLists",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointLists_Students_StudentId",
                table: "PointLists",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_References_Languages_LanguageId",
                table: "References",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_References_OnlineServices_OnlineServiceId",
                table: "References",
                column: "OnlineServiceId",
                principalTable: "OnlineServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceTypeId",
                table: "References",
                column: "ReferenceTypeId",
                principalTable: "ReferenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_References_Students_StudentId",
                table: "References",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Libraries_LibraryId",
                table: "Rooms",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Faculties_FacultyId",
                table: "Specializations",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Sections_SectionId",
                table: "Specializations",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Sectors_SectorId",
                table: "Specializations",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Duties_DutyId",
                table: "Students",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Duties_DutyId",
                table: "Teachers",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Sections_SectionId",
                table: "Teachers",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transcripts_Languages_LanguageId",
                table: "Transcripts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcripts_OnlineServices_OnlineServiceId",
                table: "Transcripts",
                column: "OnlineServiceId",
                principalTable: "OnlineServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcripts_Students_StudentId",
                table: "Transcripts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Duties_DutyId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Rooms_RoomId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationDepartments_Duties_DutyId",
                table: "EducationDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specializations_SpecializationId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Languages_LanguageId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Rooms_RoomId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Sections_SectionId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Duties_DutyId",
                table: "Librarians");

            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Libraries_LibraryId",
                table: "Librarians");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationLists_Lessons_LessonId",
                table: "ParticipationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationLists_Students_StudentId",
                table: "ParticipationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PointLists_Lessons_LessonId",
                table: "PointLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PointLists_Students_StudentId",
                table: "PointLists");

            migrationBuilder.DropForeignKey(
                name: "FK_References_Languages_LanguageId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_References_OnlineServices_OnlineServiceId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceTypeId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_References_Students_StudentId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Libraries_LibraryId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Faculties_FacultyId",
                table: "Specializations");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Sections_SectionId",
                table: "Specializations");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Sectors_SectorId",
                table: "Specializations");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Duties_DutyId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Duties_DutyId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Sections_SectionId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcripts_Languages_LanguageId",
                table: "Transcripts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcripts_OnlineServices_OnlineServiceId",
                table: "Transcripts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcripts_Students_StudentId",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Transcripts_LanguageId",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Transcripts_OnlineServiceId",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Transcripts_StudentId",
                table: "Transcripts");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_DutyId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SectionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_DutyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_FacultyId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_SectionId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_SectorId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LibraryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_References_LanguageId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_OnlineServiceId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_ReferenceTypeId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_StudentId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_PointLists_LessonId",
                table: "PointLists");

            migrationBuilder.DropIndex(
                name: "IX_PointLists_StudentId",
                table: "PointLists");

            migrationBuilder.DropIndex(
                name: "IX_ParticipationLists_LessonId",
                table: "ParticipationLists");

            migrationBuilder.DropIndex(
                name: "IX_ParticipationLists_StudentId",
                table: "ParticipationLists");

            migrationBuilder.DropIndex(
                name: "IX_Librarians_DutyId",
                table: "Librarians");

            migrationBuilder.DropIndex(
                name: "IX_Librarians_LibraryId",
                table: "Librarians");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Journals_LanguageId",
                table: "Journals");

            migrationBuilder.DropIndex(
                name: "IX_Journals_RoomId",
                table: "Journals");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CourseId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecializationId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_EducationDepartments_DutyId",
                table: "EducationDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_RoomId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_DutyId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Transcripts");

            migrationBuilder.DropColumn(
                name: "OnlineServiceId",
                table: "Transcripts");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Transcripts");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "OnlineServiceId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ReferenceTypeId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "PointLists");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "PointLists");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "ParticipationLists");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ParticipationLists");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Librarians");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Librarians");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "EducationDepartments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Announcements");
        }
    }
}
