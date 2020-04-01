using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid_19_Tracker.Persistence.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ville = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Codepostal = table.Column<int>(nullable: false),
                    Address_1 = table.Column<string>(nullable: true),
                    Address_2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    CIN = table.Column<string>(nullable: true),
                    Sexe = table.Column<int>(nullable: false),
                    NumeroTel = table.Column<string>(nullable: true),
                    AddresseId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    Date_Declaration = table.Column<DateTime>(nullable: true),
                    Date_Dernier_Contact = table.Column<DateTime>(nullable: true),
                    Nombre_Contacts = table.Column<int>(nullable: true),
                    Lien = table.Column<string>(nullable: true),
                    DateDernierCreation = table.Column<DateTime>(nullable: true),
                    NiveauRisque = table.Column<int>(nullable: true),
                    DateFin = table.Column<DateTime>(nullable: true),
                    NombreJours = table.Column<int>(nullable: true),
                    Actif = table.Column<bool>(nullable: true),
                    CasPositifParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnes_Personnes_CasPositifParentId",
                        column: x => x.CasPositifParentId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnes_Addresses_AddresseId",
                        column: x => x.AddresseId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichesSuivi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp_M = table.Column<int>(nullable: false),
                    Temp_S = table.Column<int>(nullable: false),
                    Toux_M = table.Column<bool>(nullable: false),
                    Toux_S = table.Column<bool>(nullable: false),
                    casSuiviId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesSuivi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichesSuivi_Personnes_casSuiviId",
                        column: x => x.casSuiviId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichesSuivi_casSuiviId",
                table: "FichesSuivi",
                column: "casSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_CasPositifParentId",
                table: "Personnes",
                column: "CasPositifParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_AddresseId",
                table: "Personnes",
                column: "AddresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichesSuivi");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
