using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRuanganTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peminjaman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaPeminjam = table.Column<string>(type: "TEXT", nullable: false),
                    NRP = table.Column<string>(type: "TEXT", nullable: false),
                    NamaRuangan = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalPinjam = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TanggalSelesai = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Keperluan = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjaman", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruangan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaRuangan = table.Column<string>(type: "TEXT", nullable: false),
                    Kapasitas = table.Column<int>(type: "INTEGER", nullable: false),
                    Lokasi = table.Column<string>(type: "TEXT", nullable: false),
                    Fasilitas = table.Column<string>(type: "TEXT", nullable: true),
                    IsAktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruangan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeminjamanId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusLama = table.Column<string>(type: "TEXT", nullable: false),
                    StatusBaru = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalPerubahan = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ruangan",
                columns: new[] { "Id", "Fasilitas", "IsAktif", "Kapasitas", "Lokasi", "NamaRuangan" },
                values: new object[,]
                {
                    { 1, "Proyektor, AC, Whiteboard", true, 40, "Gedung C Lantai 3", "C-303" },
                    { 2, "Proyektor, AC, Whiteboard, Sound System", true, 35, "Gedung B Lantai 1", "B-104" },
                    { 3, "Proyektor, AC, Whiteboard, Komputer", true, 50, "Gedung A Lantai 3", "A-301" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peminjaman");

            migrationBuilder.DropTable(
                name: "Ruangan");

            migrationBuilder.DropTable(
                name: "StatusHistory");
        }
    }
}
