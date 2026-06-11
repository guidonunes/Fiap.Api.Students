using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Students.Migrations
{
    /// <inheritdoc />
    public partial class CreateRepresentativesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API_REPRESENTATIVES",
                columns: table => new
                {
                    RepresentativeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RepresentativeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_REPRESENTATIVES", x => x.RepresentativeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_API_REPRESENTATIVES_Cpf",
                table: "API_REPRESENTATIVES",
                column: "Cpf",
                unique: true,
                filter: "\"Cpf\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API_REPRESENTATIVES");
        }
    }
}
