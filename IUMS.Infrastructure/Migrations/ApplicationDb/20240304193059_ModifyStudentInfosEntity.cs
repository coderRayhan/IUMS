using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class ModifyStudentInfosEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "Std_StudentBasicInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "Std_StudentBasicInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
