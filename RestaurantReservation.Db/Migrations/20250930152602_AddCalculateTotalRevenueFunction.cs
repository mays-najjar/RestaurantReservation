using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddCalculateTotalRevenueFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION dbo.CalculateTotalRevenue(@restaurant_id INT)
            RETURNS DECIMAL(10,2)
            AS
            BEGIN
                DECLARE @TotalRevenue DECIMAL(10,2);
                SELECT @TotalRevenue = SUM(o.total_amount)
                FROM Orders o
                JOIN Reservations r ON o.reservation_id = r.reservation_id
                WHERE r.restaurant_id = @restaurant_id;
                RETURN ISNULL(@TotalRevenue, 0);
            END
           ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalRevenue");
        }
    }
}
