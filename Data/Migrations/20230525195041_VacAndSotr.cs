using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAP_10.Data.Migrations
{
    public partial class VacAndSotr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sotrydnik",
                columns: table => new
                {
                    SotrydnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subdivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sotrydnik", x => x.SotrydnikId);
                });

            migrationBuilder.CreateTable(
                name: "Vacation",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacation_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vacation_pay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    holiday_benefits = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.VacationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sotrydnik");

            migrationBuilder.DropTable(
                name: "Vacation");
        }
    }
}
