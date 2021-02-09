using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capgemini_test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    Unitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
