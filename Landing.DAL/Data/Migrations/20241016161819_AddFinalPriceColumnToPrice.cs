using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFinalPriceColumnToPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceValue",
                table: "Prices",
                newName: "InitalPrice");

            migrationBuilder.AddColumn<int>(
                name: "FinalPrice",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "InitalPrice",
                table: "Prices",
                newName: "PriceValue");
        }
    }
}
