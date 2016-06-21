using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreCodeFirstMigrations.Migrations
{
    public partial class ImplementStylesLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Beers");

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.ID);
                });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BreweryName",
                table: "Beers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Beers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_StyleId",
                table: "Beers",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Style_StyleId",
                table: "Beers",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Style_StyleId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_StyleId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Beers");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BreweryName",
                table: "Beers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Beers",
                nullable: true);
        }
    }
}
