using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTeamsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkendInLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstgramLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65f90e62-778c-46e5-851a-7a5c0e1e5e32", null, "Admin", "ADMIN" },
                    { "a2be1ab7-1fe8-4796-989f-e7d9d33e8dae", null, "SuperAdmin", "SUPERADMIN" },
                    { "b588352d-7d10-462f-b35a-14f22bc9ef3d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2849dd02-a96b-4203-95df-e1dc9bfc5170", 0, null, null, "3b6ce289-8040-48a5-a83f-879ef2ec0c29", "SuperAdmin@SuperAdmin.com", true, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAELIfM791ksfggGYZYUbn+ITL1I/M6BAOjtfObmRMIMyTIz8AM5LaRgFYwwvUxIen8A==", null, false, "b2d8f149-5f18-4a19-9db1-2274d32d3fda", false, "SuperAdmin@SuperAdmin.com" },
                    { "8611396c-1416-42b9-a8c6-654129863323", 0, null, null, "b181c738-dab0-4920-ad3a-1740d361df90", "User@User.com", true, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAEK/NiYVTC/HjFdpBXYHLcvaqxT6OnSjXo83iIV7FnFZmR2/Yl8gSveDhiDYDtzK6hA==", null, false, "4ad6de58-bf53-47d2-8d99-d813f52165fa", false, "User@User.com" },
                    { "ae5cb502-ae08-4630-a91c-609ec721b173", 0, null, null, "bdf2def3-0fe6-42d6-9e4b-9c2c1e93f26d", "Admin@Admin.com", true, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEHl30X2EjsAzX+3ZPlqmeQGjso0K6/v9y4h386i/XDNo4q/AERAyZZ4lYPbqUMIj8Q==", null, false, "11486c26-2457-45a4-b412-ea085ae8fa7c", false, "Admin@Admin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a2be1ab7-1fe8-4796-989f-e7d9d33e8dae", "2849dd02-a96b-4203-95df-e1dc9bfc5170" },
                    { "b588352d-7d10-462f-b35a-14f22bc9ef3d", "8611396c-1416-42b9-a8c6-654129863323" },
                    { "65f90e62-778c-46e5-851a-7a5c0e1e5e32", "ae5cb502-ae08-4630-a91c-609ec721b173" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a2be1ab7-1fe8-4796-989f-e7d9d33e8dae", "2849dd02-a96b-4203-95df-e1dc9bfc5170" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b588352d-7d10-462f-b35a-14f22bc9ef3d", "8611396c-1416-42b9-a8c6-654129863323" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65f90e62-778c-46e5-851a-7a5c0e1e5e32", "ae5cb502-ae08-4630-a91c-609ec721b173" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f90e62-778c-46e5-851a-7a5c0e1e5e32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2be1ab7-1fe8-4796-989f-e7d9d33e8dae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b588352d-7d10-462f-b35a-14f22bc9ef3d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2849dd02-a96b-4203-95df-e1dc9bfc5170");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8611396c-1416-42b9-a8c6-654129863323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae5cb502-ae08-4630-a91c-609ec721b173");

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
    }
}
