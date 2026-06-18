using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterprisePlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Employees");
        }
    }
}
