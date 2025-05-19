using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplyBuddy.Server.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Listings_ListingId1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Channels_ApplicationChannelId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ApplicationChannelId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ListingId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Position_CompanyId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Description",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_EmploymentType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Level",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Location",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Name",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Salary_Amount",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Position_Salary_Currency",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ListingId1",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Position_Salary_Type",
                table: "Listings",
                newName: "PositionId");

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Submissions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EmploymentType = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: true),
                    Salary_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Salary_Currency = table.Column<int>(type: "integer", nullable: false),
                    Salary_Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ChannelId",
                table: "Submissions",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_PositionId",
                table: "Listings",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Positions_PositionId",
                table: "Listings",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Channels_ChannelId",
                table: "Submissions",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Positions_PositionId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Channels_ChannelId",
                table: "Submissions");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ChannelId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Listings_PositionId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Listings",
                newName: "Position_Salary_Type");

            migrationBuilder.AddColumn<int>(
                name: "Position_CompanyId",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position_Description",
                table: "Listings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position_EmploymentType",
                table: "Listings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position_Level",
                table: "Listings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position_Location",
                table: "Listings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position_Name",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Position_Salary_Amount",
                table: "Listings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Position_Salary_Currency",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ListingId1",
                table: "Applications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ApplicationChannelId",
                table: "Submissions",
                column: "ApplicationChannelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Channels_ApplicationChannelId",
                table: "Submissions",
                column: "ApplicationChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }
    }
}
