using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DictionaryApp.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictionaryEntries",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hungarian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spanish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chinese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Portugese = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryEntries", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryEntries");
        }
    }
}
