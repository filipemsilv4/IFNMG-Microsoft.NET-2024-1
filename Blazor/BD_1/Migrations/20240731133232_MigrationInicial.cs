using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BD_1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Preço = table.Column<double>(type: "REAL", nullable: false),
                    Descr = table.Column<string>(type: "TEXT", nullable: true),
                    Quant = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descr", "Nome", "Preço", "Quant" },
                values: new object[,]
                {
                    { 1001, "Excelente notebook", "Laptop", 2000.02, 10 },
                    { 1002, "Um MS Office", "Microsoft Office", 400.99000000000001, 50 },
                    { 1003, "Um mouse que funciona", "Mouse", 12.02, 20 },
                    { 1004, "Armazene incríveis 256GB de dados", "HD USB", 5.0, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
