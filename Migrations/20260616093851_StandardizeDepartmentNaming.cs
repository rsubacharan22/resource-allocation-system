using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterprisePlatform.Migrations
{
    /// <inheritdoc />
    public partial class StandardizeDepartmentNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dept_head",
                table: "Departments",
                newName: "DeptHead");

            migrationBuilder.RenameColumn(
                name: "Dept_code",
                table: "Departments",
                newName: "DeptCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeptHead",
                table: "Departments",
                newName: "Depthead");

            migrationBuilder.RenameColumn(
                name: "DeptCode",
                table: "Departments",
                newName: "Deptcode");
        }
    }
}
