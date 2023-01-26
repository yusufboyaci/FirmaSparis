using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaSiparis.DATAACCESS.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmaAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OnayDurumu = table.Column<bool>(type: "bit", nullable: false),
                    SiparisIzinBasSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiparisIzinBitisSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaZamanı = table.Column<DateTime>(name: "Oluşturulma Zamanı", type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(name: "Güncellenme Zamanı", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaZamanı = table.Column<DateTime>(name: "Oluşturulma Zamanı", type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(name: "Güncellenme Zamanı", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiparisiVereninAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaZamanı = table.Column<DateTime>(name: "Oluşturulma Zamanı", type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(name: "Güncellenme Zamanı", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparisler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_FirmaId",
                table: "Siparisler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UrunId",
                table: "Siparisler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_FirmaId",
                table: "Urunler",
                column: "FirmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Firmalar");
        }
    }
}
