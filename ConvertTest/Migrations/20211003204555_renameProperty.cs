using Microsoft.EntityFrameworkCore.Migrations;

namespace ConvertTest.Migrations
{
    public partial class renameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InitatedDate",
                table: "Calls",
                newName: "Date");

            migrationBuilder.AddColumn<long>(
                name: "CallId",
                table: "Calls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Calls");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Calls",
                newName: "InitatedDate");
        }
    }
}
