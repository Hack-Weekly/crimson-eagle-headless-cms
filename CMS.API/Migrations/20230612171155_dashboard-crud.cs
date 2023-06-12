using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMS.API.Migrations
{
    /// <inheritdoc />
    public partial class dashboardcrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "userFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmsProjectId = table.Column<int>(type: "int", nullable: false),
                    UploadedById = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userFiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e928ba1-8389-403f-aefa-db531b4ee8e0", null, "ProjectEditor", "PROJEDITOR" },
                    { "a6685cb5-4ac9-4d8b-bae2-3c0a3fbc9c81", null, "ProjectUser", "PROJUSER" },
                    { "f85e42c0-8295-4429-8235-10f74196dc2d", null, "ProjectOwner", "PROJOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsProjectOwner", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "cmsProjectId" },
                values: new object[,]
                {
                    { "339126f9-e837-474a-9953-b76417453917", 0, "ce5e963a-2d6f-4743-aec6-5bb200f12a35", "ProjectOwner2@example.com", false, "ProjectOwner", true, "Example Two", false, null, null, null, "Example Organization", null, null, false, "7b7c560a-452e-430a-983b-a4ef1ca97883", false, null, null },
                    { "3bc94cb1-50f4-4254-b787-83407663bf8a", 0, "9c20691a-5896-41c6-aaf4-c7c1ac0492aa", "ProjectUser2@example.com", false, "ProjectUser", false, "Example Two", false, null, null, null, "Example Organization", null, null, false, "54c39931-dfd6-46a0-aac7-e945bd3b9fcc", false, null, null },
                    { "c7d969d2-225e-4d55-988c-c8f87acee819", 0, "4f901fd5-3ad4-4349-8300-dedd9221bc18", "ProjectEditor@example.com", false, "ProjectEditor", false, "Example One", false, null, null, null, "Example Organization", null, null, false, "7b6f01a3-034d-4352-a7ec-cebb459b4eaf", false, null, null },
                    { "f3d7fbd7-d973-4559-bc25-f0e338bb2f45", 0, "499d6543-ee8b-400f-a42e-eacc4206a9f1", "ProjectOwner1@example.com", false, "ProjectOwner", true, "Example One", false, null, null, null, "Example Organization", null, null, false, "60cd6913-1053-4c23-b03c-24738e408375", false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 12, 17, 11, 54, 966, DateTimeKind.Utc).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 12, 17, 11, 54, 966, DateTimeKind.Utc).AddTicks(448));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userFiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e928ba1-8389-403f-aefa-db531b4ee8e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6685cb5-4ac9-4d8b-bae2-3c0a3fbc9c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f85e42c0-8295-4429-8235-10f74196dc2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "339126f9-e837-474a-9953-b76417453917");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bc94cb1-50f4-4254-b787-83407663bf8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7d969d2-225e-4d55-988c-c8f87acee819");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3d7fbd7-d973-4559-bc25-f0e338bb2f45");

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

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 9, 18, 12, 0, 962, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 9, 18, 12, 0, 962, DateTimeKind.Utc).AddTicks(8959));
        }
    }
}
