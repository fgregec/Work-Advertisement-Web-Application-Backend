using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Natjecaj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MestarCategory_Categories_CategoryId",
                table: "MestarCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MestarCategory_Users_MestarId",
                table: "MestarCategory");

            migrationBuilder.RenameTable(
                name: "MestarCategory",
                newName: "MestarCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "NatjecajId",
                table: "NatjecajStatus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MestarId",
                table: "NatjecajStatus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "NatjecajStatus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "MestarDescription",
                table: "NatjecajStatus",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "NatjecajStatus",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "NatjecajStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "MestarId",
                table: "MestarCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "MestarCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "MestarCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NatjecajStatus",
                table: "NatjecajStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MestarCategories",
                table: "MestarCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajStatus_MestarId",
                table: "NatjecajStatus",
                column: "MestarId");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajStatus_NatjecajId",
                table: "NatjecajStatus",
                column: "NatjecajId");

            migrationBuilder.CreateIndex(
                name: "IX_MestarCategories_CategoryId",
                table: "MestarCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MestarCategories_MestarId",
                table: "MestarCategories",
                column: "MestarId");

            migrationBuilder.AddForeignKey(
                name: "FK_MestarCategories_Categories_CategoryId",
                table: "MestarCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MestarCategories_Users_MestarId",
                table: "MestarCategories",
                column: "MestarId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MestarCategories_Categories_CategoryId",
                table: "MestarCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MestarCategories_Users_MestarId",
                table: "MestarCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NatjecajStatus",
                table: "NatjecajStatus");

            migrationBuilder.DropIndex(
                name: "IX_NatjecajStatus_MestarId",
                table: "NatjecajStatus");

            migrationBuilder.DropIndex(
                name: "IX_NatjecajStatus_NatjecajId",
                table: "NatjecajStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MestarCategories",
                table: "MestarCategories");

            migrationBuilder.DropIndex(
                name: "IX_MestarCategories_CategoryId",
                table: "MestarCategories");

            migrationBuilder.DropIndex(
                name: "IX_MestarCategories_MestarId",
                table: "MestarCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NatjecajStatus");

            migrationBuilder.DropColumn(
                name: "MestarDescription",
                table: "NatjecajStatus");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "NatjecajStatus");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NatjecajStatus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MestarCategories");

            migrationBuilder.RenameTable(
                name: "MestarCategories",
                newName: "MestarCategory");

            migrationBuilder.AlterColumn<Guid>(
                name: "NatjecajId",
                table: "NatjecajStatus",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "MestarId",
                table: "NatjecajStatus",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "MestarId",
                table: "MestarCategory",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "MestarCategory",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MestarCategory_Categories_CategoryId",
                table: "MestarCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MestarCategory_Users_MestarId",
                table: "MestarCategory",
                column: "MestarId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
