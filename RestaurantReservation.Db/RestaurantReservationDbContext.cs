using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ReservationWithDetails> ReservationDetails { get; set; }
        public DbSet<EmployeeWithRestaurant> EmployeesWithRestaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Restaurant)
                .WithMany(r => r.Employees)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Restaurant)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithMany(r => r.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(m => m.OrderItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Mays", LastName = "Najjar", Email = "mays@example.com", PhoneNumber = "1234567890" },
                new Customer { CustomerId = 2, FirstName = "Ali", LastName = "Khan", Email = "ali@example.com", PhoneNumber = "2345678901" },
                new Customer { CustomerId = 3, FirstName = "Sara", LastName = "Ahmed", Email = "sara@example.com", PhoneNumber = "3456789012" },
                new Customer { CustomerId = 4, FirstName = "Omar", LastName = "Saleh", Email = "omar@example.com", PhoneNumber = "4567890123" },
                new Customer { CustomerId = 5, FirstName = "Lina", LastName = "Hassan", Email = "lina@example.com", PhoneNumber = "5678901234" }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Sunset Grill", Address = "123 Street A", PhoneNumber = "1111111111", OpeningHours = "9am-10pm" },
                new Restaurant { RestaurantId = 2, Name = "Moonlight Dine", Address = "456 Street B", PhoneNumber = "2222222222", OpeningHours = "10am-11pm" },
                new Restaurant { RestaurantId = 3, Name = "Star Café", Address = "789 Street C", PhoneNumber = "3333333333", OpeningHours = "8am-9pm" },
                new Restaurant { RestaurantId = 4, Name = "Ocean Breeze", Address = "101 Street D", PhoneNumber = "4444444444", OpeningHours = "11am-12am" },
                new Restaurant { RestaurantId = 5, Name = "Mountain Eatery", Address = "202 Street E", PhoneNumber = "5555555555", OpeningHours = "7am-8pm" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Ahmed", LastName = "Ali", Position = "Manager" },
                new Employee { EmployeeId = 2, RestaurantId = 1, FirstName = "Nora", LastName = "Omar", Position = "Chef" },
                new Employee { EmployeeId = 3, RestaurantId = 2, FirstName = "Sami", LastName = "Khaled", Position = "Manager" },
                new Employee { EmployeeId = 4, RestaurantId = 3, FirstName = "Laila", LastName = "Hassan", Position = "Waiter" },
                new Employee { EmployeeId = 5, RestaurantId = 4, FirstName = "Omar", LastName = "Saleh", Position = "Chef" }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { ItemId = 1, RestaurantId = 1, Name = "Burger", Description = "Beef burger", Price = 5.99m },
                new MenuItem { ItemId = 2, RestaurantId = 1, Name = "Salad", Description = "Fresh salad", Price = 4.50m },
                new MenuItem { ItemId = 3, RestaurantId = 2, Name = "Pizza", Description = "Cheese pizza", Price = 7.99m },
                new MenuItem { ItemId = 4, RestaurantId = 3, Name = "Pasta", Description = "Tomato pasta", Price = 6.50m },
                new MenuItem { ItemId = 5, RestaurantId = 4, Name = "Steak", Description = "Grilled steak", Price = 12.00m }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 4 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 8 }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 2 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Now.AddDays(2), PartySize = 2 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 2, TableId = 3, ReservationDate = DateTime.Now.AddDays(1), PartySize = 4 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 3, TableId = 4, ReservationDate = DateTime.Now.AddDays(3), PartySize = 3 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 4, TableId = 5, ReservationDate = DateTime.Now.AddDays(4), PartySize = 6 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Now, TotalAmount = 15.50m },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = DateTime.Now, TotalAmount = 12.00m },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = DateTime.Now, TotalAmount = 20.00m },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = DateTime.Now, TotalAmount = 18.75m },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = DateTime.Now, TotalAmount = 30.00m }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2, Price = 5.99m },
                new OrderItem { OrderItemId = 2, OrderId = 1, ItemId = 2, Quantity = 1, Price = 4.50m },
                new OrderItem { OrderItemId = 3, OrderId = 2, ItemId = 3, Quantity = 1, Price = 7.99m },
                new OrderItem { OrderItemId = 4, OrderId = 3, ItemId = 4, Quantity = 3, Price = 6.50m },
                new OrderItem { OrderItemId = 5, OrderId = 4, ItemId = 5, Quantity = 2, Price = 12.00m }
            );
            modelBuilder.Entity<ReservationWithDetails>()
            .ToView("ReservationWithDetails")
            .HasNoKey();

            modelBuilder.Entity<EmployeeWithRestaurant>()
            .ToView("vw_EmployeesWithRestaurant")
            .HasNoKey();
        } 
    }
}
