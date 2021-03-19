using Microsoft.EntityFrameworkCore.Migrations;

namespace laundry.Data.Migrations
{
    public partial class user_string_and_model_binding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laundry_AspNetUsers_OwnerId",
                table: "Laundry");

            migrationBuilder.DropIndex(
                name: "IX_Laundry_OwnerId",
                table: "Laundry");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Laundry",
                newName: "Owner");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Laundry",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Laundry",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Laundry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laundry_OwnerId",
                table: "Laundry",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laundry_AspNetUsers_OwnerId",
                table: "Laundry",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
