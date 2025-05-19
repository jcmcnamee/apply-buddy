using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyBuddy.Server.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationListingRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applications_ListingId",
                table: "Applications",
                column: "ListingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Listings_ListingId",
                table: "Applications",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Listings_ListingId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ListingId",
                table: "Applications");
        }
    }
}
