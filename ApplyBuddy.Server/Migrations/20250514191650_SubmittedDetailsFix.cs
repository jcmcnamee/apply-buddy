using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplyBuddy.Server.Migrations
{
    /// <inheritdoc />
    public partial class SubmittedDetailsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Channels_ChannelId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Submissions",
                newName: "ApplicationChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ChannelId",
                table: "Submissions",
                newName: "IX_Submissions_ApplicationChannelId");

            migrationBuilder.RenameColumn(
                name: "DiscoverySource",
                table: "Listings",
                newName: "DiscoverySourceId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedDate",
                table: "Submissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_DiscoverySourceId",
                table: "Listings",
                column: "DiscoverySourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Channels_DiscoverySourceId",
                table: "Listings",
                column: "DiscoverySourceId",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Channels_ApplicationChannelId",
                table: "Submissions",
                column: "ApplicationChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Channels_DiscoverySourceId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Channels_ApplicationChannelId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Listings_DiscoverySourceId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "AppliedDate",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "ApplicationChannelId",
                table: "Submissions",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ApplicationChannelId",
                table: "Submissions",
                newName: "IX_Submissions_ChannelId");

            migrationBuilder.RenameColumn(
                name: "DiscoverySourceId",
                table: "Listings",
                newName: "DiscoverySource");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Channels_ChannelId",
                table: "Submissions",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
