using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreGroupJoin.Migrations
{
    public partial class AddOtherParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OtherParentId",
                table: "Child",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OtherParent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherParent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_OtherParentId",
                table: "Child",
                column: "OtherParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_OtherParent_OtherParentId",
                table: "Child",
                column: "OtherParentId",
                principalTable: "OtherParent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_OtherParent_OtherParentId",
                table: "Child");

            migrationBuilder.DropTable(
                name: "OtherParent");

            migrationBuilder.DropIndex(
                name: "IX_Child_OtherParentId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "OtherParentId",
                table: "Child");
        }
    }
}
