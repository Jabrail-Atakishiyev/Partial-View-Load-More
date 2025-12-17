using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPractiece.Migrations
{
    /// <inheritdoc />
    public partial class addDescColumnToSliderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Sliders");
        }
    }
}
