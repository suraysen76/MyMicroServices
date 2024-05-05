using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpNo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpNo",
                table: "Employees");
        }
    }
}
