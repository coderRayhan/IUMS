using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class ModifyEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodGroupId",
                table: "Emp_Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeePhotoUrl",
                table: "Emp_Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "EmployeePhotoUrl",
                table: "Emp_Employees");
        }
    }
}
