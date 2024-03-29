﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.DataAccessLayer.Migrations
{
    public partial class Example2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Vehiscles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Vehiscles");
        }
    }
}
