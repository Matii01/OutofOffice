using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOfficeData.Migrations
{
    /// <inheritdoc />
    public partial class UpdataApprovalRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_LeaverRequest",
                table: "ApprovalRequests",
                column: "LeaverRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_LeaveRequests_LeaverRequest",
                table: "ApprovalRequests",
                column: "LeaverRequest",
                principalTable: "LeaveRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_LeaveRequests_LeaverRequest",
                table: "ApprovalRequests");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequests_LeaverRequest",
                table: "ApprovalRequests");
        }
    }
}
