using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AirportWebApiBSA.DAL.Migrations
{
    public partial class Attributes_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Pilots",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pilots",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Pilots",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Pilots",
                newName: "Name");
        }
    }
}
