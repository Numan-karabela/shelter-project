using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarinakAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnımalId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Animal_ID",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Tel_No",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Applicants",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Applicants",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Applicants",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Applicants",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "AnımalId",
                table: "BasketItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Animal_ID",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tel_No",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
