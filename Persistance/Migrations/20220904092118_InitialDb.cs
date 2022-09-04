using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "CreatedAt", "CreatedBy", "EndDate", "IsDeleted", "Price", "StartDate", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("4ec068d7-bd75-4287-8645-abb410393999"), "Java", new DateTime(2022, 9, 4, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8427), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 9, 14, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8428), false, 1000.0, new DateTime(2022, 9, 7, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "CreatedAt", "CreatedBy", "EndDate", "IsDeleted", "Price", "StartDate", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("e8178143-015a-4a2e-a028-57fd827c72eb"), "C#", new DateTime(2022, 9, 4, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8408), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 10, 4, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8425), false, 250.0, new DateTime(2022, 9, 8, 12, 21, 18, 434, DateTimeKind.Local).AddTicks(8418), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
