using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuHotelEnLinea.Migrations
{
    public partial class UltimateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageExtra",
                table: "PackageExtra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerXRoom",
                table: "CustomerXRoom");

            migrationBuilder.AddColumn<int>(
                name: "PackageExtraId",
                table: "PackageExtra",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerXRoomId",
                table: "CustomerXRoom",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageExtra",
                table: "PackageExtra",
                column: "PackageExtraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerXRoom",
                table: "CustomerXRoom",
                column: "CustomerXRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageExtra_PackageId",
                table: "PackageExtra",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerXRoom_CustomerId",
                table: "CustomerXRoom",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageExtra",
                table: "PackageExtra");

            migrationBuilder.DropIndex(
                name: "IX_PackageExtra_PackageId",
                table: "PackageExtra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerXRoom",
                table: "CustomerXRoom");

            migrationBuilder.DropIndex(
                name: "IX_CustomerXRoom_CustomerId",
                table: "CustomerXRoom");

            migrationBuilder.DropColumn(
                name: "PackageExtraId",
                table: "PackageExtra");

            migrationBuilder.DropColumn(
                name: "CustomerXRoomId",
                table: "CustomerXRoom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageExtra",
                table: "PackageExtra",
                columns: new[] { "PackageId", "ExtraId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerXRoom",
                table: "CustomerXRoom",
                columns: new[] { "CustomerId", "RoomId" });
        }
    }
}
