using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImageColumnToBlogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3245aa09-4070-4dff-9d05-e14e8147e023", null, "Admin", "ADMIN" },
                    { "3b808596-ee5a-4297-9703-a51f38c726ab", null, "SuperAdmin", "SUPERADMIN" },
                    { "5e8e207b-6583-4cd9-b36a-9817a1b91f1c", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8c373ad0-f284-47e0-84a3-7cdbe9f21684", 0, null, null, "a867d820-d493-42d2-9648-1dd0ac8412ae", "SuperAdmin@SuperAdmin.com", true, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAENeqokl/6B9TtpCyiNncDnWxeBGrVnqfk1nnT1AEAXYyPn+gxyn8FEViGR64PZt4bA==", null, false, "a1fa3140-0fe6-4b52-8a72-17f1bcdfc3f1", false, "SuperAdmin@SuperAdmin.com" },
                    { "bdadcc5a-571c-49de-8218-557e3382f7ad", 0, null, null, "092bdd02-7a45-40f9-9db0-21d8dfa89f1a", "Admin@Admin.com", true, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEM4HmlItkUP3aYPH9MpFjDOolAHX4uNltO3pFm0DiBpi/sXgPVTbaoCO9ekcO/Ateg==", null, false, "3afda326-25e7-4e73-a2fd-6475268c8d63", false, "Admin@Admin.com" },
                    { "ec56ad86-01c3-4fb1-977e-1c04078d7aaf", 0, null, null, "82f924eb-4caa-460e-b6b9-29cd9282fab2", "User@User.com", true, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAEEHZS3YCnYg8K84OGMsJtp7rVylTCSNbdjst2F6Pe/siWg559iIjjIrPJuW0c9A96g==", null, false, "de50f10d-6ae8-445c-a443-62edc459ae45", false, "User@User.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3b808596-ee5a-4297-9703-a51f38c726ab", "8c373ad0-f284-47e0-84a3-7cdbe9f21684" },
                    { "3245aa09-4070-4dff-9d05-e14e8147e023", "bdadcc5a-571c-49de-8218-557e3382f7ad" },
                    { "5e8e207b-6583-4cd9-b36a-9817a1b91f1c", "ec56ad86-01c3-4fb1-977e-1c04078d7aaf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3b808596-ee5a-4297-9703-a51f38c726ab", "8c373ad0-f284-47e0-84a3-7cdbe9f21684" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3245aa09-4070-4dff-9d05-e14e8147e023", "bdadcc5a-571c-49de-8218-557e3382f7ad" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e8e207b-6583-4cd9-b36a-9817a1b91f1c", "ec56ad86-01c3-4fb1-977e-1c04078d7aaf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3245aa09-4070-4dff-9d05-e14e8147e023");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b808596-ee5a-4297-9703-a51f38c726ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e8e207b-6583-4cd9-b36a-9817a1b91f1c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c373ad0-f284-47e0-84a3-7cdbe9f21684");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdadcc5a-571c-49de-8218-557e3382f7ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec56ad86-01c3-4fb1-977e-1c04078d7aaf");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Blogs");

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
    }
}
