using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferPath.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobPortalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "JobApplications",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "JobApplications",
                newName: "JobType");

            migrationBuilder.RenameColumn(
                name: "AppliedDate",
                table: "JobApplications",
                newName: "PostedDate");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "JobApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExperienceLevel",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ExperienceLevel",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "JobApplications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PostedDate",
                table: "JobApplications",
                newName: "AppliedDate");

            migrationBuilder.RenameColumn(
                name: "JobType",
                table: "JobApplications",
                newName: "Notes");
        }
    }
}
