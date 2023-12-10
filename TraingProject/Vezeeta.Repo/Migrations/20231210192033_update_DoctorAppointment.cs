using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vezeeta.Repo.Migrations
{
    /// <inheritdoc />
    public partial class update_DoctorAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Clinics_ClinicID",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointmentTimes_DoctorAppointments_DoctorAppointmentID",
                table: "DoctorAppointmentTimes");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "DoctorAppointments",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointments_ClinicID",
                table: "DoctorAppointments",
                newName: "IX_DoctorAppointments_DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Users_DoctorID",
                table: "DoctorAppointments",
                column: "DoctorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointmentTimes_DoctorAppointments_DoctorAppointmentID",
                table: "DoctorAppointmentTimes",
                column: "DoctorAppointmentID",
                principalTable: "DoctorAppointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Users_DoctorID",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointmentTimes_DoctorAppointments_DoctorAppointmentID",
                table: "DoctorAppointmentTimes");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "DoctorAppointments",
                newName: "ClinicID");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointments_DoctorID",
                table: "DoctorAppointments",
                newName: "IX_DoctorAppointments_ClinicID");

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID1 = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clinics_Users_DoctorID1",
                        column: x => x.DoctorID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DoctorID1",
                table: "Clinics",
                column: "DoctorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Clinics_ClinicID",
                table: "DoctorAppointments",
                column: "ClinicID",
                principalTable: "Clinics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointmentTimes_DoctorAppointments_DoctorAppointmentID",
                table: "DoctorAppointmentTimes",
                column: "DoctorAppointmentID",
                principalTable: "DoctorAppointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
