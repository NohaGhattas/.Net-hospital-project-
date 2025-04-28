using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomUsers",
                columns: new[] { "UserID", "CreatedBy", "CreatedDate", "Email", "ModifiedBy", "ModifiedDate", "PasswordHash", "Status", "StoredSalt", "UserName" },
                values: new object[] { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@example.com", 1, null, "k+JnIJpsQygTcddYGWdYmu4oY12yUQpqhIJoD9M+HV+Rs1BUGk6sbTxYv6CVMk8xzIxhwavf3Sd498ksayvwoQ==", null, new byte[] { 45, 151, 52, 75, 22, 234, 26, 47, 182, 151, 200, 214, 114, 72, 157, 212, 154, 82, 163, 186, 152, 169, 159, 188, 125, 1, 9, 44, 32, 68, 238, 233, 130, 145, 47, 196, 202, 140, 147, 48, 55, 35, 203, 181, 104, 192, 57, 19, 233, 179, 216, 140, 227, 152, 33, 159, 2, 20, 183, 4, 43, 119, 189, 178, 211, 81, 231, 44, 139, 227, 82, 45, 177, 123, 63, 74, 88, 220, 224, 187, 0, 12, 128, 102, 87, 252, 185, 137, 254, 214, 187, 93, 140, 54, 156, 105, 0, 17, 197, 157, 154, 4, 113, 90, 164, 12, 196, 220, 41, 217, 101, 53, 182, 91, 63, 17, 190, 28, 236, 189, 115, 208, 157, 7, 89, 193, 199, 60 }, "test2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomUsers",
                keyColumn: "UserID",
                keyValue: 4);
        }
    }
}
