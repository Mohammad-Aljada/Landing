using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRelationShipBetweenPriceAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08684144-1b8a-4bd4-b72a-64d04d487c0e", "3f353318-93c6-4523-b1c8-28c4d6f027bd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "772f3d89-59a3-4d71-a3d4-e758ee779976", "72f77311-4e99-421d-92d5-823b696b4712" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0533a0e0-4459-4970-beeb-b37a2f8339dd", "79fff52c-b293-4290-a643-d76bd2227f27" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0533a0e0-4459-4970-beeb-b37a2f8339dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08684144-1b8a-4bd4-b72a-64d04d487c0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772f3d89-59a3-4d71-a3d4-e758ee779976");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f353318-93c6-4523-b1c8-28c4d6f027bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72f77311-4e99-421d-92d5-823b696b4712");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79fff52c-b293-4290-a643-d76bd2227f27");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PriceId",
                table: "AspNetUsers",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Prices_PriceId",
                table: "AspNetUsers",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Prices_PriceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PriceId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0533a0e0-4459-4970-beeb-b37a2f8339dd", null, "Admin", "ADMIN" },
                    { "08684144-1b8a-4bd4-b72a-64d04d487c0e", null, "User", "USER" },
                    { "772f3d89-59a3-4d71-a3d4-e758ee779976", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f353318-93c6-4523-b1c8-28c4d6f027bd", 0, "Tulkerm", null, "1bc2cd1a-4068-4965-9ee3-c77cf541e815", "User@User.com", true, null, null, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAIAAYagAAAAECbr//+1W7J/0du/VBDPv8c8ds248im0aiRhqqZz0yzi8qYwEv1cPsopv0qrhnnQRw==", "0568524048", false, "386dae0a-cfe5-4634-bbc1-a5d6ead9cd1a", false, "User@User.com" },
                    { "72f77311-4e99-421d-92d5-823b696b4712", 0, "Tulkerm", null, "9a31015a-60f8-45c9-9d79-ad55b4a89208", "SuperAdmin@SuperAdmin.com", true, null, null, false, null, "SUPERADMIN@SUPERADMIN.com", "SUPERADMIN@SUPERADMIN.com", "AQAAAAIAAYagAAAAEOABtanJKZ3Mm3hohu20baHfOHHdWU1NgKckJZIv3s1j34We6h0aCQK+8ZsaCGNiNQ==", "0568524048", false, "f5fcffdb-19a0-4998-a8b2-126f8f8875da", false, "SuperAdmin@SuperAdmin.com" },
                    { "79fff52c-b293-4290-a643-d76bd2227f27", 0, "Tulkerm", null, "3bf8fb82-8d7b-4224-b5af-a3b55136890c", "Admin@Admin.com", true, null, null, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAIAAYagAAAAELFKXXg0Ava5tTOYdktA/5yxaprzKW2EIkc4j06n5gvNCFgG7fiU63AYkTSaMZbwhg==", "0568524048", false, "fab1ffc3-5957-4597-815e-537b7914495c", false, "Admin@Admin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "08684144-1b8a-4bd4-b72a-64d04d487c0e", "3f353318-93c6-4523-b1c8-28c4d6f027bd" },
                    { "772f3d89-59a3-4d71-a3d4-e758ee779976", "72f77311-4e99-421d-92d5-823b696b4712" },
                    { "0533a0e0-4459-4970-beeb-b37a2f8339dd", "79fff52c-b293-4290-a643-d76bd2227f27" }
                });
        }
    }
}
