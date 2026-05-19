using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBDTask9.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufactures",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "INTL", new DateTime(1968, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Corporation" },
                    { 2, "AMD", new DateTime(1969, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced Micro Devices" },
                    { 3, "NVDA", new DateTime(1993, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvidia Corporation" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Central Processing Unit" },
                    { 2, "GPU", "Graphics Processing Unit" },
                    { 3, "RAM", "Random Access Memory" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5f },
                    { 2, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.2f },
                    { 3, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workstation Pro", 3, 48, 8f }
                });

            migrationBuilder.InsertData(
                table: "Componets",
                columns: new[] { "Code", "ComponentManufactorId", "ComponentTypeId", "Desciption", "Name" },
                values: new object[,]
                {
                    { "A", 1, 1, "High end CPU", "Intel Core i9" },
                    { "B", 2, 2, "High end GPU", "AMD Radeon RX" },
                    { "C", 3, 2, "Top tier GPU", "Nvidia RTX 4090" }
                });

            migrationBuilder.InsertData(
                table: "PCComponets",
                columns: new[] { "ComponetCode", "PCId", "ComponetAmount" },
                values: new object[,]
                {
                    { "A", 1, 1 },
                    { "B", 1, 2 },
                    { "C", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PCComponets",
                keyColumns: new[] { "ComponetCode", "PCId" },
                keyValues: new object[] { "A", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponets",
                keyColumns: new[] { "ComponetCode", "PCId" },
                keyValues: new object[] { "B", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponets",
                keyColumns: new[] { "ComponetCode", "PCId" },
                keyValues: new object[] { "C", 2 });

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Componets",
                keyColumn: "Code",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "Componets",
                keyColumn: "Code",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "Componets",
                keyColumn: "Code",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufactures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufactures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufactures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
