using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGalaxy_Auction_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class PaymentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Vehicle_VehicleId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistory_Vehicle_VehicleId",
                table: "PaymentHistory");

            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "PaymentHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentInentId",
                table: "PaymentHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7127), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 15, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7142), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7145), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7148), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7150), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7153), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7156), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7160), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7162), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7165), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7168), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7171), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7174), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7176), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7180), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7183), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7186), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7189), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7191), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7191) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 4, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7194), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7194) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 11, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7197), new DateTime(2025, 1, 22, 15, 3, 10, 155, DateTimeKind.Local).AddTicks(7196) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Vehicle_VehicleId",
                table: "Bids",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistory_Vehicle_VehicleId",
                table: "PaymentHistory",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Vehicle_VehicleId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistory_Vehicle_VehicleId",
                table: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "StripePaymentInentId",
                table: "PaymentHistory");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1593), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 11, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1603), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1607), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1610), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1613), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1616), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1619), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1621), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1621) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1624), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1627), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1629), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1629) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1633), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1636), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1638), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1638) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1641), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1641) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1644), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1646), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1651), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1650) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1653), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 31, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1656), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 7, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1658), new DateTime(2025, 1, 18, 16, 54, 10, 853, DateTimeKind.Local).AddTicks(1658) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Vehicle_VehicleId",
                table: "Bids",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistory_Vehicle_VehicleId",
                table: "PaymentHistory",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId");
        }
    }
}
