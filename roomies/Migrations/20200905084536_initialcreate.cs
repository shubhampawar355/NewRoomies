using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace roomies.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    FilterId = table.Column<int>(nullable: false),
                    MinBudget = table.Column<float>(nullable: false),
                    MaxBudget = table.Column<float>(nullable: false),
                    MinRoomCount = table.Column<int>(nullable: false),
                    MaxRoomCount = table.Column<int>(nullable: false),
                    MinSharingCount = table.Column<int>(nullable: false),
                    MaxSharingCount = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.FilterId);
                    table.ForeignKey(
                        name: "FK_Filters_Users_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Rent = table.Column<float>(nullable: false),
                    VisiblityStatus = table.Column<int>(nullable: false),
                    ValidateStatus = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    RoomCount = table.Column<int>(nullable: false),
                    SharingCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    FlatNo = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Landmark = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Addresses_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRooms",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRooms", x => new { x.UserId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_UserRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRooms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OwnerId",
                table: "Rooms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRooms_RoomId",
                table: "UserRooms",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "UserRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
