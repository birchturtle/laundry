using Microsoft.EntityFrameworkCore.Migrations;

namespace laundry.Data.Migrations
{
    public partial class typeofwash_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfWash",
                table: "Laundry",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfWash",
                table: "Laundry");
        }
    }
}
