using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Users_UserId",
                table: "Information");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Information",
                table: "Information");

            migrationBuilder.RenameTable(
                name: "Information",
                newName: "Informations");

            migrationBuilder.RenameIndex(
                name: "IX_Information_UserId",
                table: "Informations",
                newName: "IX_Informations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informations",
                table: "Informations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_Users_UserId",
                table: "Informations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informations_Users_UserId",
                table: "Informations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informations",
                table: "Informations");

            migrationBuilder.RenameTable(
                name: "Informations",
                newName: "Information");

            migrationBuilder.RenameIndex(
                name: "IX_Informations_UserId",
                table: "Information",
                newName: "IX_Information_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Information",
                table: "Information",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Users_UserId",
                table: "Information",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
