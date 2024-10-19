using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carDescriptions_Cars_CarId",
                table: "carDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brandsd_BrandId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carDescriptions",
                table: "carDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brandsd",
                table: "Brandsd");

            migrationBuilder.RenameTable(
                name: "carDescriptions",
                newName: "CarDescriptions");

            migrationBuilder.RenameTable(
                name: "Brandsd",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_carDescriptions_CarId",
                table: "CarDescriptions",
                newName: "IX_CarDescriptions_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDescriptions",
                table: "CarDescriptions",
                column: "CarDescriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDescriptions",
                table: "CarDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "CarDescriptions",
                newName: "carDescriptions");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brandsd");

            migrationBuilder.RenameIndex(
                name: "IX_CarDescriptions_CarId",
                table: "carDescriptions",
                newName: "IX_carDescriptions_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carDescriptions",
                table: "carDescriptions",
                column: "CarDescriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brandsd",
                table: "Brandsd",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_carDescriptions_Cars_CarId",
                table: "carDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brandsd_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brandsd",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
