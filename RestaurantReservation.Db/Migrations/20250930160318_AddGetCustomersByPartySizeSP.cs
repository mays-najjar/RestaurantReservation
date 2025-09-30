using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddGetCustomersByPartySizeSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GetCustomersByPartySize
                    @MinPartySize INT
                AS
                BEGIN
                    SELECT DISTINCT c.customer_id, c.first_name, c.last_name, c.email, c.phone_number
                    FROM Customers c
                    JOIN Reservations r ON c.customer_id = r.customer_id
                    WHERE r.party_size > @MinPartySize
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetCustomersByPartySize");
        }
    }
}
