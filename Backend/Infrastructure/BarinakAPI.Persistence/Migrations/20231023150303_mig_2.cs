using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarinakAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Applicants_ApplicantId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ApplicantId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Baskets");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Baskets_BasketId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_BasketId",
                table: "Applicants");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ApplicantId",
                table: "Baskets",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Applicants_ApplicantId",
                table: "Baskets",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
