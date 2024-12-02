using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare_API.Migrations
{
    /// <inheritdoc />
    public partial class mudancaclienteeproblema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasSaude_Clientes_ClienteId",
                table: "ProblemasSaude");

            migrationBuilder.DropIndex(
                name: "IX_ProblemasSaude_ClienteId",
                table: "ProblemasSaude");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ProblemasSaude");

            migrationBuilder.CreateTable(
                name: "ClienteProblemaSaude",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProblemaSaudeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProblemaSaude", x => new { x.ClienteId, x.ProblemaSaudeId });
                    table.ForeignKey(
                        name: "FK_ClienteProblemaSaude_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteProblemaSaude_ProblemasSaude_ProblemaSaudeId",
                        column: x => x.ProblemaSaudeId,
                        principalTable: "ProblemasSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProblemaSaude_ProblemaSaudeId",
                table: "ClienteProblemaSaude",
                column: "ProblemaSaudeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteProblemaSaude");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ProblemasSaude",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProblemasSaude_ClienteId",
                table: "ProblemasSaude",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasSaude_Clientes_ClienteId",
                table: "ProblemasSaude",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
