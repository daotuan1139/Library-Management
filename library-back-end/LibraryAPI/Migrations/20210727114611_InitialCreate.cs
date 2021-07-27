using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequest",
                columns: table => new
                {
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalUserRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminApproved = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequest", x => x.BookBorrowingRequestID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "NormalUser",
                columns: table => new
                {
                    NormalUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalUser", x => x.NormalUserID);
                });

            migrationBuilder.CreateTable(
                name: "SuperlUser",
                columns: table => new
                {
                    SuperUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperlUser", x => x.SuperUserID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetail",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    BookBorrowingRequestID = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetail", x => new { x.BookBorrowingRequestID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetail_BookBorrowingRequest_BookBorrowingRequestID",
                        column: x => x.BookBorrowingRequestID,
                        principalTable: "BookBorrowingRequest",
                        principalColumn: "BookBorrowingRequestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "BookName" },
                values: new object[] { 1, "Book 1" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Category 1" });

            migrationBuilder.InsertData(
                table: "NormalUser",
                columns: new[] { "NormalUserID", "NormalUserEmail", "NormalUserName", "NormalUserPassword" },
                values: new object[] { 1, "1", "user 1", "1" });

            migrationBuilder.InsertData(
                table: "SuperlUser",
                columns: new[] { "SuperUserID", "SuperUserEmail", "SuperUserName", "SuperUserPassword" },
                values: new object[] { 1, "1", "admin 1", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetail_BookID",
                table: "BookBorrowingRequestDetail",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "NormalUser");

            migrationBuilder.DropTable(
                name: "SuperlUser");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequest");
        }
    }
}
