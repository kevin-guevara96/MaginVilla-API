using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVilla",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVilla", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NumeroVilla_Villa_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 3, 27, 12, 59, 50, 223, DateTimeKind.Local).AddTicks(9523), new DateTime(2024, 3, 27, 12, 59, 50, 223, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 3, 27, 12, 59, 50, 223, DateTimeKind.Local).AddTicks(9525), new DateTime(2024, 3, 27, 12, 59, 50, 223, DateTimeKind.Local).AddTicks(9525) });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVilla_VillaId",
                table: "NumeroVilla",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVilla");

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6869), new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6872), new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6871) });
        }
    }
}
