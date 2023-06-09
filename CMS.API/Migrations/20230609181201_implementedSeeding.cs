using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMS.API.Migrations
{
    /// <inheritdoc />
    public partial class implementedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "AspNetUsers",
                newName: "OrganizationName");

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectOwner",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cmsProjectId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CMSProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectOwnerId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSProjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "147edc61-d8d6-435e-9c8d-86e5dc4000db", null, "ProjectUser", "PROJUSER" },
                    { "3f5870d6-cc43-4c2b-9d37-2eccdbf3fe5c", null, "ProjectEditor", "PROJEDITOR" },
                    { "58214f4c-8191-48bd-870a-a1e82386511d", null, "ProjectOwner", "PROJOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsProjectOwner", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "cmsProjectId" },
                values: new object[,]
                {
                    { "0c248897-ee92-44c5-af6e-2bec2e3e8a81", 0, "63896c21-3aed-4754-af0f-cf4f683c4762", "ProjectEditor@example.com", false, "ProjectEditor", false, "Example One", false, null, null, null, "Example Organization", null, null, false, "b54c0a65-a406-4dc8-9ada-b1093554ffa3", false, null, null },
                    { "8366a1e5-787c-43dc-947e-d424bf6edfc1", 0, "3d71d8ce-3507-4955-8fb6-4ea14ed38bce", "ProjectUser2@example.com", false, "ProjectUser", false, "Example Two", false, null, null, null, "Example Organization", null, null, false, "58826020-91d8-4fac-a582-741a08af56e3", false, null, null },
                    { "84e2578e-95db-4f36-a714-4cbe4840bb64", 0, "f8159244-5dce-401c-86ee-d64e5cd54214", "ProjectOwner2@example.com", false, "ProjectOwner", true, "Example Two", false, null, null, null, "Example Organization", null, null, false, "e9e7f2a6-1ef4-445b-8a4a-f60faf467c4a", false, null, null },
                    { "8ec31953-8a6f-47d5-8a7b-debc31b80e23", 0, "0687bfec-5a40-436a-b4d4-fdd78f1f88a2", "ProjectOwner1@example.com", false, "ProjectOwner", true, "Example One", false, null, null, null, "Example Organization", null, null, false, "e47b4a91-212c-499d-b313-c2ad9c3f4760", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "CMSProjects",
                columns: new[] { "Id", "IsActive", "LastUpdated", "Name", "ProjectOwnerId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 6, 9, 18, 12, 0, 962, DateTimeKind.Utc).AddTicks(8953), "project 1 ", 1 },
                    { 2, true, new DateTime(2023, 6, 9, 18, 12, 0, 962, DateTimeKind.Utc).AddTicks(8959), "project 2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cmsProjectId",
                table: "AspNetUsers",
                column: "cmsProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CMSProjects_cmsProjectId",
                table: "AspNetUsers",
                column: "cmsProjectId",
                principalTable: "CMSProjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CMSProjects_cmsProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CMSProjects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cmsProjectId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "147edc61-d8d6-435e-9c8d-86e5dc4000db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f5870d6-cc43-4c2b-9d37-2eccdbf3fe5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58214f4c-8191-48bd-870a-a1e82386511d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c248897-ee92-44c5-af6e-2bec2e3e8a81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8366a1e5-787c-43dc-947e-d424bf6edfc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84e2578e-95db-4f36-a714-4cbe4840bb64");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ec31953-8a6f-47d5-8a7b-debc31b80e23");

            migrationBuilder.DropColumn(
                name: "IsProjectOwner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cmsProjectId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "AspNetUsers",
                newName: "CompanyName");
        }
    }
}
