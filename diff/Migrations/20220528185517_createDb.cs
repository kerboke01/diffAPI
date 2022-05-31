using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diff.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    dataLeft = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    dataRight = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllData");
        }
    }
}
