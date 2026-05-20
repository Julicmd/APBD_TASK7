using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBDTask9.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCComponets_Componets_ComponetCode",
                table: "PCComponets");

            migrationBuilder.DropForeignKey(
                name: "FK_PCComponets_PCs_PCId",
                table: "PCComponets");

            migrationBuilder.DropTable(
                name: "Componets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets");

            migrationBuilder.RenameTable(
                name: "PCComponets",
                newName: "PcComponents");

            migrationBuilder.RenameColumn(
                name: "PCId",
                table: "PcComponents",
                newName: "PcId");

            migrationBuilder.RenameColumn(
                name: "ComponetCode",
                table: "PcComponents",
                newName: "ComponentCode");

            migrationBuilder.RenameIndex(
                name: "IX_PCComponets_ComponetCode",
                table: "PcComponents",
                newName: "IX_PcComponents_ComponentCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PcComponents",
                table: "PcComponents",
                columns: new[] { "PcId", "ComponentCode" });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentManufactorId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Components_ComponentManufactures_ComponentManufactorId",
                        column: x => x.ComponentManufactorId,
                        principalTable: "ComponentManufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_ComponentTypes_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ComponentManufactures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Abbreviation",
                value: "NVDIA");

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufactorId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "A", 1, 1, "High end CPU", "Intel Core i9" },
                    { "B", 2, 2, "High end GPU", "AMD Radeon RX" },
                    { "C", 3, 2, "Top tier GPU", "Nvidia RTX 4090" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentManufactorId",
                table: "Components",
                column: "ComponentManufactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypeId",
                table: "Components",
                column: "ComponentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PcComponents_Components_ComponentCode",
                table: "PcComponents",
                column: "ComponentCode",
                principalTable: "Components",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcComponents_PCs_PcId",
                table: "PcComponents",
                column: "PcId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcComponents_Components_ComponentCode",
                table: "PcComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PcComponents_PCs_PcId",
                table: "PcComponents");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PcComponents",
                table: "PcComponents");

            migrationBuilder.RenameTable(
                name: "PcComponents",
                newName: "PCComponets");

            migrationBuilder.RenameColumn(
                name: "PcId",
                table: "PCComponets",
                newName: "PCId");

            migrationBuilder.RenameColumn(
                name: "ComponentCode",
                table: "PCComponets",
                newName: "ComponetCode");

            migrationBuilder.RenameIndex(
                name: "IX_PcComponents_ComponentCode",
                table: "PCComponets",
                newName: "IX_PCComponets_ComponetCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCComponets",
                table: "PCComponets",
                columns: new[] { "PCId", "ComponetCode" });

            migrationBuilder.CreateTable(
                name: "Componets",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ComponentManufactorId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componets", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Componets_ComponentManufactures_ComponentManufactorId",
                        column: x => x.ComponentManufactorId,
                        principalTable: "ComponentManufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componets_ComponentTypes_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ComponentManufactures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Abbreviation",
                value: "NVDA");

            migrationBuilder.InsertData(
                table: "Componets",
                columns: new[] { "Code", "ComponentManufactorId", "ComponentTypeId", "Desciption", "Name" },
                values: new object[,]
                {
                    { "A", 1, 1, "High end CPU", "Intel Core i9" },
                    { "B", 2, 2, "High end GPU", "AMD Radeon RX" },
                    { "C", 3, 2, "Top tier GPU", "Nvidia RTX 4090" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componets_ComponentManufactorId",
                table: "Componets",
                column: "ComponentManufactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Componets_ComponentTypeId",
                table: "Componets",
                column: "ComponentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCComponets_Componets_ComponetCode",
                table: "PCComponets",
                column: "ComponetCode",
                principalTable: "Componets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PCComponets_PCs_PCId",
                table: "PCComponets",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
