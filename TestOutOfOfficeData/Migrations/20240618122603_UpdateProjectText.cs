using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOutOfOfficeData.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Projects",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Projects",
                newName: "Text");
        }
    }
}
