using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrintTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentName = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentPathReference = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentSQLQuery = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    PrintTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintDocuments_PrintTypes_PrintTypeId",
                        column: x => x.PrintTypeId,
                        principalTable: "PrintTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Printers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrinterName = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrinterTCP = table.Column<bool>(type: "INTEGER", nullable: false),
                    IPv4 = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    PortSerial = table.Column<string>(type: "TEXT", nullable: false),
                    Driver = table.Column<string>(type: "TEXT", nullable: false),
                    PrintTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Printers_PrintTypes_PrintTypeId",
                        column: x => x.PrintTypeId,
                        principalTable: "PrintTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DocumentParameters = table.Column<string>(type: "TEXT", nullable: false),
                    PrinterId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfCopy = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintQueues_PrintDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "PrintDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrintQueues_Printers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintDocuments_PrintTypeId",
                table: "PrintDocuments",
                column: "PrintTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_PrintTypeId",
                table: "Printers",
                column: "PrintTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintQueues_DocumentId",
                table: "PrintQueues",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintQueues_PrinterId",
                table: "PrintQueues",
                column: "PrinterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrintQueues");

            migrationBuilder.DropTable(
                name: "PrintDocuments");

            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "PrintTypes");
        }
    }
}
