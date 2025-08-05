using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Destek.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("59d7a5b7-b54d-4f3a-8223-88d154f294f3"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("ead2b783-b192-48e0-b88d-6497ece1d847"));

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TCKN", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c94f1447-0d1d-45c8-9304-152e4796119b"), 0, "31748a6c-11fa-415a-85d1-e3a04b21c634", "burhan.ozdemir@sirnak.edu.tr", true, "Burhan", "Özdemir", false, null, "BURHAN.OZDEMIR@SIRNAK.EDU.TR", "BURHAN", "AQAAAAIAAYagAAAAEEzWrVX33eA1BSNp8aOOgW5gc7S6JEdGz+9q76RmB/skHLAPdk+UyCpNUFM6vwCgdw==", "+905466279280", true, null, null, "5ca23d30-efb9-4547-a8aa-79d84b88cf67", "036b4c8a-e730-48ac-8700-caa6c847961d", false, "burhan" },
                    { new Guid("d8edeb55-9fe3-4b47-b085-c0afd54b104a"), 0, "16a3ed80-d5a0-4fe1-ba62-ba2bfa0b537a", "burhanozdemir.01@gmail.com", true, "Admin", "Admin", false, null, "BURHANOZDEMIR.01@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEDO1k3Nm+oeWPHiZbqhKIkibANQ85qmYzLmIOjLXQVG7urlA13LnrtxNfOCZNv7JCQ==", "+905466279280", true, null, null, "f674827f-1850-4af3-a40f-49fb2271dba7", "3b98d449-4bff-4baf-87c4-d890e762babe", false, "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("c94f1447-0d1d-45c8-9304-152e4796119b"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8edeb55-9fe3-4b47-b085-c0afd54b104a"));

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TCKN", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("59d7a5b7-b54d-4f3a-8223-88d154f294f3"), 0, "6e6972c4-aaa3-4e7c-a2bd-8b54624b558e", "burhan.ozdemir@sirnak.edu.tr", true, "Burhan", "Özdemir", false, null, "BURHAN.OZDEMIR@SIRNAK.EDU.TR", "BURHAN", "AQAAAAIAAYagAAAAEL8uI+LiTndbZa8VOHF4mwo1FUUz1lvMHkiyLCobNF84AuB5zQCNLa46UCcqh8ynPQ==", "+905466279280", true, null, null, "316ea276-bda5-4955-9e68-3d911b9df87d", "0f359842-7090-4cbd-80c2-81ec1a25c0de", false, "burhan" },
                    { new Guid("ead2b783-b192-48e0-b88d-6497ece1d847"), 0, "ad936b16-e7a9-4851-ade9-e23365550b73", "burhanozdemir.01@gmail.com", true, "Admin", "Admin", false, null, "BURHANOZDEMIR.01@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEBIMMY2y69YqRXi6A2PdHrm8LJfXZaIUNFnTGi0lXbIYI8rsMLrWeH22yrkIL3343Q==", "+905466279280", true, null, null, "7f1aa979-600d-4eee-8690-96c7e5c76b4a", "6664c569-517b-40ce-b0c1-af85ade6cfd9", false, "Admin" }
                });
        }
    }
}
