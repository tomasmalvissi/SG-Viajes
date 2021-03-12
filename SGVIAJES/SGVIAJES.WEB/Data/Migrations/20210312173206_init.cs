using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGVIAJES.WEB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroViaje = table.Column<int>(type: "int", nullable: false),
                    FechaViaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KM = table.Column<float>(type: "real", nullable: false),
                    PrecioKM = table.Column<float>(type: "real", nullable: false),
                    MinEsper = table.Column<float>(type: "real", nullable: false),
                    PrecioEspera = table.Column<float>(type: "real", nullable: false),
                    PeajeEst = table.Column<float>(type: "real", nullable: false),
                    GNC = table.Column<float>(type: "real", nullable: false),
                    Nafta = table.Column<float>(type: "real", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    ImporteEsp = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}
