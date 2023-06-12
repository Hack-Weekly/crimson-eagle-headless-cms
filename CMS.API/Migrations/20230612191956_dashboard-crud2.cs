using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMS.API.Migrations
{
    /// <inheritdoc />
    public partial class dashboardcrud2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "acb9de61-6dfc-4d0d-b5e7-888ae82d75ef", null, "ProjectEditor", "PROJEDITOR" },
                    { "ad1a83bf-bba1-4629-bbfd-c34190da45b5", null, "ProjectUser", "PROJUSER" },
                    { "b129e61a-53e6-4fe1-9dfb-94e91be30f91", null, "ProjectOwner", "PROJOWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "IsProjectOwner", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "cmsProjectId" },
                values: new object[,]
                {
                    { "121b789d-22f9-47a5-8a32-8d1236e0a83b", 0, "62a48e4e-87e3-407d-8e94-58b52a3d338e", "ProjectUser2@example.com", false, "ProjectUser", false, "Example Two", false, null, null, null, "Example Organization", null, null, false, "32506be5-9a16-4261-acdc-dc504c3a1f31", false, null, null },
                    { "1b55dc3d-7519-4039-afa9-86469afb7796", 0, "04ee1949-ccae-41b7-ba92-adeca1ea29cd", "ProjectEditor@example.com", false, "ProjectEditor", false, "Example One", false, null, null, null, "Example Organization", null, null, false, "17c573ba-547c-4fc5-9dbb-ff8d73263821", false, null, null },
                    { "96110b3f-a1b6-4685-9df7-8921f073c6ae", 0, "e9b2bf97-f076-4d9f-9316-dea24465b005", "ProjectOwner1@example.com", false, "ProjectOwner", true, "Example One", false, null, null, null, "Example Organization", null, null, false, "65b0b355-62bf-4969-b06e-df80bdc7ac67", false, null, null },
                    { "a4017746-ab3a-4ce1-817b-d7778b928be6", 0, "92df524a-448a-4aa2-b791-8c5a0a0ae4e1", "ProjectOwner2@example.com", false, "ProjectOwner", true, "Example Two", false, null, null, null, "Example Organization", null, null, false, "5b17d506-9821-4da5-b218-aed5335945cf", false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 12, 19, 19, 56, 308, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "CMSProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2023, 6, 12, 19, 19, 56, 308, DateTimeKind.Utc).AddTicks(5209));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acb9de61-6dfc-4d0d-b5e7-888ae82d75ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad1a83bf-bba1-4629-bbfd-c34190da45b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b129e61a-53e6-4fe1-9dfb-94e91be30f91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "121b789d-22f9-47a5-8a32-8d1236e0a83b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b55dc3d-7519-4039-afa9-86469afb7796");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96110b3f-a1b6-4685-9df7-8921f073c6ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4017746-ab3a-4ce1-817b-d7778b928be6");

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
    }
}
