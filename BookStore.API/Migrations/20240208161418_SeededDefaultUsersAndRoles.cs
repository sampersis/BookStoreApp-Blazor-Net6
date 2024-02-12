using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26edbb25-0042-46bf-9192-b37fbc78561c", null, "User", "USER" },
                    { "fa826e82-b733-4b92-9a45-fb30f3cbc166", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20e74a0b-06d1-48e2-b2e7-860719dab25b", 0, "99335143-2450-47a9-bc5b-e4ab2f87ae8d", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEELQ/z1qQ6D/YJfYlDiS304eTBDNF//vyx5oFwoqXyTeNhjhF7IUBBtDbwawOXZM9g==", null, false, "339bbe12-df07-4b49-ad99-baf58fede654", false, "user@bookstore.com" },
                    { "fffd1919-af93-452c-adb6-efd6e36e41a7", 0, "0e3ec8e8-6876-4323-b0e6-5582169963e3", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEFV1HDzMy4o/M9Cy0RJBuEWDlKLLLKn7aNzk7kz4CWm0k/a0OYUWzJMVmjT9ZUvKrA==", null, false, "5de5829b-8f39-441a-b324-ba96353fb8ce", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "26edbb25-0042-46bf-9192-b37fbc78561c", "20e74a0b-06d1-48e2-b2e7-860719dab25b" },
                    { "fa826e82-b733-4b92-9a45-fb30f3cbc166", "fffd1919-af93-452c-adb6-efd6e36e41a7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "26edbb25-0042-46bf-9192-b37fbc78561c", "20e74a0b-06d1-48e2-b2e7-860719dab25b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa826e82-b733-4b92-9a45-fb30f3cbc166", "fffd1919-af93-452c-adb6-efd6e36e41a7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26edbb25-0042-46bf-9192-b37fbc78561c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa826e82-b733-4b92-9a45-fb30f3cbc166");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20e74a0b-06d1-48e2-b2e7-860719dab25b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fffd1919-af93-452c-adb6-efd6e36e41a7");
        }
    }
}
