using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class editApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b5babefb-f752-4aaf-8126-37521bc05bea", "3b9709b6-7ea3-4d04-82da-afde7aa64d1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0474091-3c2b-481d-8b11-8b1c103a4e5e", "6a07cedb-d2a9-4ab6-a11c-3997ae2109dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d995fca3-5725-4ff3-a933-624809bf0cc9", "95ca7618-73f6-444b-a6f5-c649ce9f7e75" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5babefb-f752-4aaf-8126-37521bc05bea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d995fca3-5725-4ff3-a933-624809bf0cc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0474091-3c2b-481d-8b11-8b1c103a4e5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b9709b6-7ea3-4d04-82da-afde7aa64d1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a07cedb-d2a9-4ab6-a11c-3997ae2109dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95ca7618-73f6-444b-a6f5-c649ce9f7e75");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21b230ff-0f8d-4cab-bd71-e45587841e3d", null, "Admin", "ADMIN" },
                    { "3ed5e005-3a06-4095-8916-02a64a90b0bd", null, "SuperAdmin", "SUPERADMIN" },
                    { "92132bba-18bd-4d1a-bb7a-72f3475eaee0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PriceId", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "82bc0005-9628-4806-8960-b8bdfc3287d5", 0, "Tulkerm", null, "a4a06854-328e-43b3-911f-6db246a64439", "Admin@Admin.com", true, null, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEC9mqtBfMbF/FpdteyQihQuShb6Vj40jEXbRLBz+vywMxM3/mjpoNlhbnfojgY3mGw==", "0568524048", false, null, null, "184508b3-6fbc-4c15-aecd-b7c96fed3841", false, "Admin@Admin.com" },
                    { "bb48745e-3165-49c3-a3c0-df95fe74e78f", 0, "Tulkerm", null, "ff96d020-3b1b-4231-a7ac-490fae52a8f5", "SuperAdmin@SuperAdmin.com", true, null, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAEHAOQwLydKg/4IqxsqwIwPG0YHEUSzxVEvgCol48KxWWJ7lyRirbrBURmrxJceB/uQ==", "0568524048", false, null, null, "a947a59c-246e-4a56-9315-04562a878357", false, "SuperAdmin@SuperAdmin.com" },
                    { "ec4ce338-401d-4566-801a-95d4ad5f5ac5", 0, "Tulkerm", null, "c322576b-a574-4e77-8748-5f41a63e872c", "User@User.com", true, null, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAELk14ZWxIwtaeqRnmOrYRlNmF+w/R2951P4w+QkeFy/Vuy134857VvunKxA205kSMQ==", "0568524048", false, null, null, "10b8644f-77d1-45d6-9430-f668e610787a", false, "User@User.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "21b230ff-0f8d-4cab-bd71-e45587841e3d", "82bc0005-9628-4806-8960-b8bdfc3287d5" },
                    { "3ed5e005-3a06-4095-8916-02a64a90b0bd", "bb48745e-3165-49c3-a3c0-df95fe74e78f" },
                    { "92132bba-18bd-4d1a-bb7a-72f3475eaee0", "ec4ce338-401d-4566-801a-95d4ad5f5ac5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "21b230ff-0f8d-4cab-bd71-e45587841e3d", "82bc0005-9628-4806-8960-b8bdfc3287d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ed5e005-3a06-4095-8916-02a64a90b0bd", "bb48745e-3165-49c3-a3c0-df95fe74e78f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92132bba-18bd-4d1a-bb7a-72f3475eaee0", "ec4ce338-401d-4566-801a-95d4ad5f5ac5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21b230ff-0f8d-4cab-bd71-e45587841e3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ed5e005-3a06-4095-8916-02a64a90b0bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92132bba-18bd-4d1a-bb7a-72f3475eaee0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82bc0005-9628-4806-8960-b8bdfc3287d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb48745e-3165-49c3-a3c0-df95fe74e78f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec4ce338-401d-4566-801a-95d4ad5f5ac5");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5babefb-f752-4aaf-8126-37521bc05bea", null, "Admin", "ADMIN" },
                    { "d995fca3-5725-4ff3-a933-624809bf0cc9", null, "User", "USER" },
                    { "e0474091-3c2b-481d-8b11-8b1c103a4e5e", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PriceId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b9709b6-7ea3-4d04-82da-afde7aa64d1d", 0, "Tulkerm", null, "a58e29e4-885f-4dd1-a3b1-6d0e935226b9", "Admin@Admin.com", true, null, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAEBy9GA+F3mMr/FusfJV7FL9vIvbXh0ARfGTFx1zHoPbqqdN+LKZaaKWymk9XeCRAiQ==", "0568524048", false, null, "0b69e7c3-80fb-46ae-8a94-f207e5a09989", false, "Admin@Admin.com" },
                    { "6a07cedb-d2a9-4ab6-a11c-3997ae2109dc", 0, "Tulkerm", null, "a06ca124-541c-44c8-b93a-1f3aa6cf5c4c", "SuperAdmin@SuperAdmin.com", true, null, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAEK/2AXyxLQrgIK2uOlxy1Moin0LkSp/2pj7liioX905nJlibuMrYDt/ZbSQAB/BqZw==", "0568524048", false, null, "b336ef23-254e-45fa-8b5e-ea40d030ecd2", false, "SuperAdmin@SuperAdmin.com" },
                    { "95ca7618-73f6-444b-a6f5-c649ce9f7e75", 0, "Tulkerm", null, "cb6276d7-d0f4-4b11-a99d-ca0627924024", "User@User.com", true, null, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAEOGYOmNprM3zWe8DAjTZ5IUwLw1GRI05ZlL+ysIBHwHLPOK0pZBpHihvukNdZaUNlQ==", "0568524048", false, null, "17ff29fc-6792-4fd7-a87c-9ac0fd31cb6c", false, "User@User.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b5babefb-f752-4aaf-8126-37521bc05bea", "3b9709b6-7ea3-4d04-82da-afde7aa64d1d" },
                    { "e0474091-3c2b-481d-8b11-8b1c103a4e5e", "6a07cedb-d2a9-4ab6-a11c-3997ae2109dc" },
                    { "d995fca3-5725-4ff3-a933-624809bf0cc9", "95ca7618-73f6-444b-a6f5-c649ce9f7e75" }
                });
        }
    }
}
