using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Natjecajs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NatjecajStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NatjecajId = table.Column<Guid>(type: "uuid", nullable: false),
                    MestarId = table.Column<Guid>(type: "uuid", nullable: false),
                    MestarDescription = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatjecajStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NatjecajStatus_Natjecaji_NatjecajId",
                        column: x => x.NatjecajId,
                        principalTable: "Natjecaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatjecajStatus_Users_MestarId",
                        column: x => x.MestarId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajStatus_MestarId",
                table: "NatjecajStatus",
                column: "MestarId");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajStatus_NatjecajId",
                table: "NatjecajStatus",
                column: "NatjecajId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NatjecajStatus");
        }
    }
}
