using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "email", "first_name", "last_name", "phone_number" },
                values: new object[,]
                {
                    { 1, "mays@example.com", "Mays", "Najjar", "1234567890" },
                    { 2, "ali@example.com", "Ali", "Khan", "2345678901" },
                    { 3, "sara@example.com", "Sara", "Ahmed", "3456789012" },
                    { 4, "omar@example.com", "Omar", "Saleh", "4567890123" },
                    { 5, "lina@example.com", "Lina", "Hassan", "5678901234" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "restaurant_id", "address", "name", "opening_hours", "phone_number" },
                values: new object[,]
                {
                    { 1, "123 Street A", "Sunset Grill", "9am-10pm", "1111111111" },
                    { 2, "456 Street B", "Moonlight Dine", "10am-11pm", "2222222222" },
                    { 3, "789 Street C", "Star Café", "8am-9pm", "3333333333" },
                    { 4, "101 Street D", "Ocean Breeze", "11am-12am", "4444444444" },
                    { 5, "202 Street E", "Mountain Eatery", "7am-8pm", "5555555555" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_id", "first_name", "last_name", "position", "restaurant_id" },
                values: new object[,]
                {
                    { 1, "Ahmed", "Ali", "Manager", 1 },
                    { 2, "Nora", "Omar", "Chef", 1 },
                    { 3, "Sami", "Khaled", "Manager", 2 },
                    { 4, "Laila", "Hassan", "Waiter", 3 },
                    { 5, "Omar", "Saleh", "Chef", 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "item_id", "description", "name", "price", "restaurant_id" },
                values: new object[,]
                {
                    { 1, "Beef burger", "Burger", 5.99m, 1 },
                    { 2, "Fresh salad", "Salad", 4.50m, 1 },
                    { 3, "Cheese pizza", "Pizza", 7.99m, 2 },
                    { 4, "Tomato pasta", "Pasta", 6.50m, 3 },
                    { 5, "Grilled steak", "Steak", 12.00m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "table_id", "capacity", "restaurant_id" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 2 },
                    { 4, 4, 3 },
                    { 5, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "reservation_id", "customer_id", "party_size", "reservation_date", "restaurant_id", "table_id" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 10, 1, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3018), 1, 1 },
                    { 2, 2, 2, new DateTime(2025, 10, 2, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3083), 1, 2 },
                    { 3, 3, 4, new DateTime(2025, 10, 1, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3098), 2, 3 },
                    { 4, 4, 3, new DateTime(2025, 10, 3, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3115), 3, 4 },
                    { 5, 5, 6, new DateTime(2025, 10, 4, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3130), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "employee_id", "order_date", "reservation_id", "total_amount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 30, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3258), 1, 15.50m },
                    { 2, 2, new DateTime(2025, 9, 30, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3275), 2, 12.00m },
                    { 3, 3, new DateTime(2025, 9, 30, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3290), 3, 20.00m },
                    { 4, 4, new DateTime(2025, 9, 30, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3305), 4, 18.75m },
                    { 5, 5, new DateTime(2025, 9, 30, 2, 31, 31, 226, DateTimeKind.Local).AddTicks(3320), 5, 30.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "order_item_id", "item_id", "order_id", "price", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 5.99m, 2 },
                    { 2, 2, 1, 4.50m, 1 },
                    { 3, 3, 2, 7.99m, 1 },
                    { 4, 4, 3, 6.50m, 3 },
                    { 5, 5, 4, 12.00m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 3);
        }
    }
}
