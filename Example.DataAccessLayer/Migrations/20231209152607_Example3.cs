using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.DataAccessLayer.Migrations
{
    public partial class Example3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Vehiscles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehiscles");

            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Vehiscles");

            migrationBuilder.AddColumn<bool>(
                name: "Wheels",
                table: "Vehiscles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wheels",
                table: "Vehiscles");

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Vehiscles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehiscles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Vehiscles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
