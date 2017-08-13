using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedFeaturesDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Ar Conditioning')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Hydraulic Steering')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Alarm')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Multimedia')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Alloy wheels')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Fog lights')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Electric rear view mirror')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
