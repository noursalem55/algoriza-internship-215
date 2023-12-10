using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vezeeta.Repo.Migrations
{
    /// <inheritdoc />
    public partial class add_DoctorsTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DoctorAppointments_DoctorAppointmentID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DoctorAppointmentID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DoctorAppointmentID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Booking",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAppointmentTimesID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DoctorAppointmentTimes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorAppointmentID = table.Column<int>(type: "int", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointmentTimes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DoctorAppointmentTimes_DoctorAppointments_DoctorAppointmentID",
                        column: x => x.DoctorAppointmentID,
                        principalTable: "DoctorAppointments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "IsAdmin",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DoctorAppointmentTimesID",
                table: "Booking",
                column: "DoctorAppointmentTimesID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointmentTimes_DoctorAppointmentID",
                table: "DoctorAppointmentTimes",
                column: "DoctorAppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DoctorAppointmentTimes_DoctorAppointmentTimesID",
                table: "Booking",
                column: "DoctorAppointmentTimesID",
                principalTable: "DoctorAppointmentTimes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DoctorAppointmentTimes_DoctorAppointmentTimesID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "DoctorAppointmentTimes");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DoctorAppointmentTimesID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DoctorAppointmentTimesID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Booking",
                newName: "Time");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DoctorAppointments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFrom",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeTo",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAppointmentID",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "IsAdmin",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DoctorAppointmentID",
                table: "Booking",
                column: "DoctorAppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DoctorAppointments_DoctorAppointmentID",
                table: "Booking",
                column: "DoctorAppointmentID",
                principalTable: "DoctorAppointments",
                principalColumn: "ID");
        }
    }
}
