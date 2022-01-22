using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourBy.Data.Persistent.Sql.Migrations
{
    public partial class AddRelationPostWithRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RouteId",
                table: "Posts",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Routes_RouteId",
                table: "Posts",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Routes_RouteId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Posts_RouteId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Posts");
        }
    }
}
