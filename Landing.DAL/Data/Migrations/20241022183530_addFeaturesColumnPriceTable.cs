using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFeaturesColumnPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47d5a973-c132-45fa-8b25-0cb752b460d5", null, "Admin", "ADMIN" },
                    { "48cf0dfd-1d1d-4892-826e-abad62ed2900", null, "User", "USER" },
                    { "cf1ba237-7342-4288-9557-0c9fbea80b4b", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "039d9ad7-ae24-4c51-9066-0aa5f2d6459d", 0, null, null, "c69e777d-c70f-4874-aaab-55cb1541acc5", "Admin@Admin.com", true, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEBkhFWtwqA6+MJujehMSIGGfyeLjStuRtiJNH12M+qEAKU6I7O2ft1bmvb3cbNkW1g==", null, false, "4da81cac-0a9d-4c3f-96cb-2f8a13ead13b", false, "Admin@Admin.com" },
                    { "4637526d-29b6-49a0-aabc-d428e272f6b8", 0, null, null, "f5325833-b8d0-41c5-9310-a2479dd4de43", "User@User.com", true, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAEEa9WIJatTcRItzNU98G/5nti1fBt3F7OzH1GgiwxG9JZfw5qH+7c/x131utyFzotA==", null, false, "7b8d538b-2962-4058-824d-92bec21e0c16", false, "User@User.com" },
                    { "f609b00f-0a62-4a89-b78d-dbb1d4e06090", 0, null, null, "9a8caec0-8760-4356-a189-3d77e69bc931", "SuperAdmin@SuperAdmin.com", true, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAEIRzyZ2nT/Plx+QHHcjatHIxSG5B75sjIlJXYd4rdpM20ulMJFQebb7rbkEkyIih0g==", null, false, "2b0a01e7-f517-4ce2-8c41-5f7a1e6e5fe9", false, "SuperAdmin@SuperAdmin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "47d5a973-c132-45fa-8b25-0cb752b460d5", "039d9ad7-ae24-4c51-9066-0aa5f2d6459d" },
                    { "48cf0dfd-1d1d-4892-826e-abad62ed2900", "4637526d-29b6-49a0-aabc-d428e272f6b8" },
                    { "cf1ba237-7342-4288-9557-0c9fbea80b4b", "f609b00f-0a62-4a89-b78d-dbb1d4e06090" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "47d5a973-c132-45fa-8b25-0cb752b460d5", "039d9ad7-ae24-4c51-9066-0aa5f2d6459d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48cf0dfd-1d1d-4892-826e-abad62ed2900", "4637526d-29b6-49a0-aabc-d428e272f6b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf1ba237-7342-4288-9557-0c9fbea80b4b", "f609b00f-0a62-4a89-b78d-dbb1d4e06090" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47d5a973-c132-45fa-8b25-0cb752b460d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48cf0dfd-1d1d-4892-826e-abad62ed2900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf1ba237-7342-4288-9557-0c9fbea80b4b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "039d9ad7-ae24-4c51-9066-0aa5f2d6459d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4637526d-29b6-49a0-aabc-d428e272f6b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f609b00f-0a62-4a89-b78d-dbb1d4e06090");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Prices");

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
    }
}
