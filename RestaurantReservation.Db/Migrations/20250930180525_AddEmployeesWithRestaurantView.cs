using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
   public partial class AddEmployeesWithRestaurantView : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
            CREATE VIEW vw_EmployeesWithRestaurant AS
            SELECT e.employee_id, e.first_name, e.last_name, e.position, r.name AS restaurant_name
            FROM Employees e
            JOIN Restaurants r ON e.restaurant_id = r.restaurant_id
        ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP VIEW IF EXISTS vw_EmployeesWithRestaurant");
    }
}

}
