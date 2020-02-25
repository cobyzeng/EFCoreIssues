using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.Infrastructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO orders.orders (OrderNumber, CustomerName) VALUES ('OrderOne', 'Coby')
                INSERT INTO orders.jobs (OrderId, JobNumber, JobStatusId) 
                SELECT Id, 'JobOne', 4 FROM orders.orders WHERE OrderNumber = 'OrderOne'
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
