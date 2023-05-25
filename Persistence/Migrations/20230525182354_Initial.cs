using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sender_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sender_Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Receiver_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Receiver_City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Receiver_Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
