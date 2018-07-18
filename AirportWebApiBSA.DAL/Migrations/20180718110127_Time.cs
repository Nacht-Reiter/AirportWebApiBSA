using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AirportWebApiBSA.DAL.Migrations
{
    public partial class Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Expirience", table: "Pilots");
            migrationBuilder.AddColumn<int>(
                name: "Expirience",
                table: "Pilots",
                nullable: true);
            migrationBuilder.DropColumn(name: "Age", table: "AirCrafts");
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AirCrafts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Expirience",
                table: "Pilots",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Age",
                table: "AirCrafts",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
