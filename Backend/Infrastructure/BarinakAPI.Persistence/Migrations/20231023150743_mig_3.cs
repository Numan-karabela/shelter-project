using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarinakAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Baskets_BasketId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_BasketId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Applicants");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Baskets_Id",
                table: "Applicants",
                column: "Id",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Baskets_Id",
                table: "Applicants");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "Applicants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_BasketId",
                table: "Applicants",
                column: "BasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Baskets_BasketId",
                table: "Applicants",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
