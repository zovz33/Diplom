using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.ASPNET.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "integer",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
