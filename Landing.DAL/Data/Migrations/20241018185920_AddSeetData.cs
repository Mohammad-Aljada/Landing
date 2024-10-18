using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeetData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04083a8d-5784-4a9a-8be5-07603a84523a", null, "SuperAdmin", "SUPERADMIN" },
                    { "0cd7ee3f-e62c-4079-a0cf-641a9117287e", null, "User", "USER" },
                    { "f8ce624e-50dd-42e1-a1b6-44597474393f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "68660409-57e6-4b3f-b0ef-dcc55e1750c1", 0, null, null, "ab6e11d6-c24b-4d62-8991-eca0063b6578", "Admin@Admin.com", true, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEJMTFvBxGCD0GzMWhfIVoGWp1b0W0rwCHMgFuMy9AK/jyvCao5x5IedkXGgdYdOWBA==", null, false, "a6812160-0150-4505-baff-c033e1feaa09", false, "Admin@Admin.com" },
                    { "dc0ba6ab-260d-4c44-b8ea-f0cc22c1d754", 0, null, null, "5ffbd956-8d86-4b05-9462-818208b81c3c", "SuperAdmin@SuperAdmin.com", true, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAEMj/XOjRdA3a/O9kb/2Ojl5/fTmtPkuurfhsImWMzlilKFC+6+5/BLRHLg2SkAZSiQ==", null, false, "a6f9160c-82af-4610-a7f5-dba8fe1358e7", false, "SuperAdmin@SuperAdmin.com" },
                    { "ed3633f6-5839-4bab-b5e0-57545854c760", 0, null, null, "f73bfccf-8955-428d-8bd8-292e376fe5c8", "User@User.com", true, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAED08tzlGB2XMeyI9B9gr+moHZMY6Sx5lJMry5Tq31sQ7y1GShdmGBLllM/XVTeyBrw==", null, false, "325bd3d9-4da9-41dc-96ba-5261f52c1af6", false, "User@User.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f8ce624e-50dd-42e1-a1b6-44597474393f", "68660409-57e6-4b3f-b0ef-dcc55e1750c1" },
                    { "04083a8d-5784-4a9a-8be5-07603a84523a", "dc0ba6ab-260d-4c44-b8ea-f0cc22c1d754" },
                    { "0cd7ee3f-e62c-4079-a0cf-641a9117287e", "ed3633f6-5839-4bab-b5e0-57545854c760" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8ce624e-50dd-42e1-a1b6-44597474393f", "68660409-57e6-4b3f-b0ef-dcc55e1750c1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04083a8d-5784-4a9a-8be5-07603a84523a", "dc0ba6ab-260d-4c44-b8ea-f0cc22c1d754" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0cd7ee3f-e62c-4079-a0cf-641a9117287e", "ed3633f6-5839-4bab-b5e0-57545854c760" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04083a8d-5784-4a9a-8be5-07603a84523a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cd7ee3f-e62c-4079-a0cf-641a9117287e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ce624e-50dd-42e1-a1b6-44597474393f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68660409-57e6-4b3f-b0ef-dcc55e1750c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc0ba6ab-260d-4c44-b8ea-f0cc22c1d754");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3633f6-5839-4bab-b5e0-57545854c760");
        }
    }
}
