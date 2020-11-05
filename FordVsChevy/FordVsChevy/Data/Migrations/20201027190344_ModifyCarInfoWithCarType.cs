using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FordVSChevy.Data.Migrations
{
    public partial class ModifyCarInfoWithCarType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarTypeId",
                table: "CarInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarInfos_CarTypeId",
                table: "CarInfos",
                column: "CarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfos_carTypes_CarTypeId",
                table: "CarInfos",
                column: "CarTypeId",
                principalTable: "carTypes",
                principalColumn: "CarTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInfos_carTypes_CarTypeId",
                table: "CarInfos");

            migrationBuilder.DropIndex(
                name: "IX_CarInfos_CarTypeId",
                table: "CarInfos");

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "CarInfos");
        }
    }
}
