using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCommentTableAndaddimagenamecolumntoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AspNetUsers");

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
    }
}
