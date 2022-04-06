using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class Teacher11v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "credits",
                table: "Teacher");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "Teacher");

            migrationBuilder.AddColumn<int>(
                name: "credits",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
