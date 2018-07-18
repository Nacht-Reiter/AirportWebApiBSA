using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AirportWebApiBSA.DAL.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Stewardesses",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stewardesses",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Stewardesses",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Stewardesses",
                newName: "Name");
        }
    }
}
