using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAP_10.Data.Migrations
{
    public partial class AddDocum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    holiday_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    holiday_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_Code_Vacation = table.Column<int>(type: "int", nullable: false),
                    F_Code_Sotrydnik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_Sotrydnik_F_Code_Sotrydnik",
                        column: x => x.F_Code_Sotrydnik,
                        principalTable: "Sotrydnik",
                        principalColumn: "SotrydnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_Vacation_F_Code_Vacation",
                        column: x => x.F_Code_Vacation,
                        principalTable: "Vacation",
                        principalColumn: "VacationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_F_Code_Sotrydnik",
                table: "Document",
                column: "F_Code_Sotrydnik");

            migrationBuilder.CreateIndex(
                name: "IX_Document_F_Code_Vacation",
                table: "Document",
                column: "F_Code_Vacation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
