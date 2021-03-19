using Microsoft.EntityFrameworkCore.Migrations;

namespace laundry.Data.Migrations
{
    public partial class attention_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Attention",
                table: "Laundry",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attention",
                table: "Laundry");
        }
    }
}
