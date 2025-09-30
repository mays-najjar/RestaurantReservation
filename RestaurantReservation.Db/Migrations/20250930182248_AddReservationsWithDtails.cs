using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddReservationsWithDtails : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql(@"
       CREATE VIEW vw_ReservationsWithDetails AS
SELECT 
    r.reservation_id AS ReservationId,
    r.reservation_date AS ReservationDate,
    r.party_size AS PartySize,
    rest.name AS RestaurantName,
    rest.address AS RestaurantAddress,
    c.first_name AS CustomerFirstName,
    c.last_name AS CustomerLastName,
    c.email AS CustomerEmail
FROM Reservations r
JOIN Restaurants rest ON r.restaurant_id = rest.restaurant_id
JOIN Customers c ON r.customer_id = c.customer_id;
    ");
}


        protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("DROP VIEW vw_ReservationsDetails");
}

    }
}
