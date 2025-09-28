# Restaurant Reservation System

This is a .NET Core console application for managing restaurant reservations using Entity Framework Core.

## Project Structure

- **RestaurantReservation**: Console application that demonstrates the functionality.
- **RestaurantReservation.Db**: Class library containing the data models, DbContext, services, and repositories.

## Database Schema

The database consists of the following tables:

- **Restaurants**: Stores restaurant information (Id, Name, Address, Phone).
- **Customers**: Stores customer information (Id, FirstName, LastName, Email, Phone).
- **Employees**: Stores employee information (Id, FirstName, LastName, Position, RestaurantId).
- **Reservations**: Stores reservation information (Id, CustomerId, RestaurantId, ReservationDate, PartySize).
- **MenuItems**: Stores menu item information (Id, RestaurantId, Name, Price).
- **Orders**: Stores order information (Id, ReservationId, EmployeeId, OrderDate, TotalAmount).
- **OrderItems**: Stores order item information (Id, OrderId, MenuItemId, Quantity, Price).
