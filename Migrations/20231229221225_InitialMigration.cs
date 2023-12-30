using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Web_Project_Fall.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    DoktorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorBrans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorSifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorUnvan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.DoktorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doktor");
        }
    }
}
