using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyBuddy.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveChannelFromApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Channels_ChannelId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ChannelId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "ListingId1",
                table: "Applications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ListingId1",
                table: "Applications",
                column: "ListingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Listings_ListingId1",
                table: "Applications",
                column: "ListingId1",
                principalTable: "Listings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Listings_ListingId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ListingId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ListingId1",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Applications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ChannelId",
                table: "Applications",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Channels_ChannelId",
                table: "Applications",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }
    }
}
