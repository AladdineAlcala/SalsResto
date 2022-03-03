using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalsResto.Web.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datereg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    booktype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noofperson = table.Column<int>(type: "int", nullable: true),
                    occasion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeofservice = table.Column<int>(type: "int", nullable: true),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    eventcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    p_id = table.Column<int>(type: "int", nullable: true),
                    reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extendedAreaId = table.Column<int>(type: "int", nullable: true),
                    apply_extendedAmount = table.Column<bool>(type: "bit", nullable: true),
                    p_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    serve_stat = table.Column<bool>(type: "bit", nullable: true),
                    is_cancelled = table.Column<bool>(type: "bit", nullable: true),
                    b_createdbyUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    b_updatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    b_createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    cId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_cId",
                        column: x => x.cId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_cId",
                table: "Bookings",
                column: "cId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
