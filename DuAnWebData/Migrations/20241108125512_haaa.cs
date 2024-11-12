using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuAnWebData.Migrations
{
    /// <inheritdoc />
    public partial class haaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_BillIdBill",
                table: "BillDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillIdBill",
                table: "BillDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_BillIdBill",
                table: "BillDetails",
                column: "BillIdBill",
                principalTable: "Bills",
                principalColumn: "IdBill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_BillIdBill",
                table: "BillDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillIdBill",
                table: "BillDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_BillIdBill",
                table: "BillDetails",
                column: "BillIdBill",
                principalTable: "Bills",
                principalColumn: "IdBill",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
