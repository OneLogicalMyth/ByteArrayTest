using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByteArrayTest.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b763f4d6-8349-4ec0-b121-ea37eaac0f26"), "Testing 123" },
                    { new Guid("665e5b61-c0a3-48bb-85a5-0359daa175a3"), "Testing 345" },
                    { new Guid("9f161009-f1ba-46df-8923-396c36d0a9df"), "Testing 678" },
                    { new Guid("fd3c7ed0-048e-44e3-a472-a7ef9cdd77b7"), "Testing 901" },
                    { new Guid("57293055-8c01-4e14-858f-8c3846c45d48"), "Testing 234" },
                    { new Guid("02ac0bc0-0509-458f-8523-90c15a5385bc"), "Testing 567" },
                    { new Guid("7e51b4a4-0d49-4622-b386-f50f3790523a"), "Testing 890" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objects_Name",
                table: "Objects",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objects");
        }
    }
}
