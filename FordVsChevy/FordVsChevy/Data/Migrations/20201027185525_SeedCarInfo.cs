using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FordVSChevy.Data.Migrations
{
    public partial class SeedCarInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into CarTypes (CarMake) values ('Chevy')");
            migrationBuilder.Sql("Insert into CarTypes (CarMake) values ('Ford')");
            migrationBuilder.Sql("Insert into CarTypes (CarMake) values ('Toyota')");
            migrationBuilder.Sql("Insert into CarTypes (CarMake) values ('Honda')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
