using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciatecnica.Migrations
{
    public partial class ClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(24)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    NameCorporateName = table.Column<string>(type: "varchar(200)", nullable: false),
                    SurnameTradeName = table.Column<string>(type: "varchar(15)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    AddressNumber = table.Column<short>(type: "smallint", nullable: false),
                    AddressComplement = table.Column<string>(type: "varchar(100)", nullable: true),
                    District = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_CpfCnpj",
                table: "clients",
                column: "CpfCnpj",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
