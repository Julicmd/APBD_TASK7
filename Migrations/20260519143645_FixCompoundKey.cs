using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBDTask9.Migrations
{
    /// <inheritdoc />
    public partial class FixCompoundKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets",
                columns: new[] { "PCId", "ComponetCode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets",
                column: "PCId");
        }
    }
}
