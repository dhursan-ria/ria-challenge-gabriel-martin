using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallenge.Infrastructure.Persistence.Migrations.Schema
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Library",
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), "Stephen King" },
                    { new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"), "Lucy Foley" },
                    { new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"), "Chris Colfer" },
                    { new Guid("5469fe52-454a-11ec-81d3-0242ac130003"), "Brandon Dorman" }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "Id", "Name", "Price", "PublishDate" },
                values: new object[,]
                {
                    { new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003"), "Later", 29.90m, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32be1a-454a-11ec-81d3-0242ac130003"), "Lisey's Story Tie-In Edition", 24.90m, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003"), "Billy Summers", 39.90m, new DateTime(2021, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32c086-454a-11ec-81d3-0242ac130003"), "Rita Hayworth and Shawshank Redemption", 19.90m, new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32c14e-454a-11ec-81d3-0242ac130003"), "The Guest List", 29.90m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32c220-454a-11ec-81d3-0242ac130003"), "The Hunting Party", 29.90m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ef32c2de-454a-11ec-81d3-0242ac130003"), "An Author's Oddyssey", 39.99m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32be1a-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32c086-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c14e-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c220-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c2de-454a-11ec-81d3-0242ac130003") },
                    { new Guid("5469fe52-454a-11ec-81d3-0242ac130003"), new Guid("ef32c2de-454a-11ec-81d3-0242ac130003") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32be1a-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fa74-454a-11ec-81d3-0242ac130003"), new Guid("ef32c086-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c14e-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c220-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"), new Guid("ef32c2de-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5469fe52-454a-11ec-81d3-0242ac130003"), new Guid("ef32c2de-454a-11ec-81d3-0242ac130003") });

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5469fa74-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5469fe52-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32be1a-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32c086-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32c14e-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32c220-454a-11ec-81d3-0242ac130003"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef32c2de-454a-11ec-81d3-0242ac130003"));
        }
    }
}
