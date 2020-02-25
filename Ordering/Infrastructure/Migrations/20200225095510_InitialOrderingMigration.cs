using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.Infrastructure.Migrations
{
    public partial class InitialOrderingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "orders");

            migrationBuilder.CreateTable(
                name: "jobstatus",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    JobNumber = table.Column<string>(maxLength: 100, nullable: true),
                    JobStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobs_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobs_jobstatus_JobStatusId",
                        column: x => x.JobStatusId,
                        principalSchema: "orders",
                        principalTable: "jobstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "orders",
                table: "jobstatus",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 2, "Assigned", "assigned" },
                    { 3, "Completed", "completed" },
                    { 4, "Draft", "draft" },
                    { 1, "Unassigned", "unassigned" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobNumber",
                schema: "orders",
                table: "jobs",
                column: "JobNumber",
                unique: true,
                filter: "[JobNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_OrderId",
                schema: "orders",
                table: "jobs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobStatusId",
                schema: "orders",
                table: "jobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderNumber",
                schema: "orders",
                table: "orders",
                column: "OrderNumber",
                unique: true,
                filter: "[OrderNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "jobstatus",
                schema: "orders");
        }
    }
}
