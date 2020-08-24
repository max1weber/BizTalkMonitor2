﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMultiTennant.Migrations
{
    public partial class AddTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ConnectionString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantInfo_Identifier",
                table: "TenantInfo",
                column: "Identifier",
                unique: true,
                filter: "[Identifier] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantInfo");
        }
    }
}
