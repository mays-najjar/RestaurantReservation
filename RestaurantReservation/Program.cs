using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<RestaurantReservationDbContext>();
                dbContext.Database.EnsureCreated();

                var service = new RestaurantReservationService(dbContext);
                await Demo(service);
            }

            Console.WriteLine("Demo finished!");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((hostContext, services) =>
        {
            var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<RestaurantReservationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<RestaurantReservationService>();
        });


        public static async Task Demo(RestaurantReservationService service)
        {
            Console.WriteLine("Seeding and testing data...");

            var restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "La Piazza", Address = "123 Main St", PhoneNumber = "123456789", OpeningHours = "10:00-22:00" },
                new Restaurant { Name = "Sushi House", Address = "456 Sushi St", PhoneNumber = "987654321", OpeningHours = "11:00-23:00" },
                new Restaurant { Name = "Burger Queen", Address = "789 Burger Rd", PhoneNumber = "111222333", OpeningHours = "09:00-21:00" },
                new Restaurant { Name = "Taco Town", Address = "321 Taco Ave", PhoneNumber = "444555666", OpeningHours = "12:00-22:00" },
                new Restaurant { Name = "Curry Palace", Address = "654 Curry Blvd", PhoneNumber = "777888999", OpeningHours = "10:00-22:00" }
            };

            foreach (var r in restaurants)
                await service.CreateRestaurantAsync(r);

            var customers = new List<Customer>
            {
                new Customer { FirstName="Mays", LastName="Najjar", Email="mays@example.com", PhoneNumber="0591111111" },
                new Customer { FirstName="Ahmad", LastName="Ali", Email="ahmad@example.com", PhoneNumber="0592222222" },
                new Customer { FirstName="Sara", LastName="Omar", Email="sara@example.com", PhoneNumber="0593333333" },
                new Customer { FirstName="Lina", LastName="Hassan", Email="lina@example.com", PhoneNumber="0594444444" },
                new Customer { FirstName="Khaled", LastName="Saleh", Email="khaled@example.com", PhoneNumber="0595555555" }
            };

            foreach (var c in customers)
                await service.CreateCustomerAsync(c);

            var employees = new List<Employee>
            {
                new Employee { FirstName="John", LastName="Doe", Position="Manager", RestaurantId=restaurants[0].RestaurantId },
                new Employee { FirstName="Jane", LastName="Smith", Position="Waiter", RestaurantId=restaurants[0].RestaurantId },
                new Employee { FirstName="Ali", LastName="Hussein", Position="Chef", RestaurantId=restaurants[1].RestaurantId },
                new Employee { FirstName="Sara", LastName="Khan", Position="Manager", RestaurantId=restaurants[2].RestaurantId },
                new Employee { FirstName="Tom", LastName="Brown", Position="Waiter", RestaurantId=restaurants[2].RestaurantId }
            };

            foreach (var e in employees)
                await service.CreateEmployeeAsync(e);

            var menuItems = new List<MenuItem>
            {
                new MenuItem { Name="Pizza", Price=12.5m, RestaurantId=restaurants[0].RestaurantId },
                new MenuItem { Name="Sushi Roll", Price=8.99m, RestaurantId=restaurants[1].RestaurantId },
                new MenuItem { Name="Burger", Price=6.5m, RestaurantId=restaurants[2].RestaurantId },
                new MenuItem { Name="Taco", Price=4.99m, RestaurantId=restaurants[3].RestaurantId },
                new MenuItem { Name="Chicken Curry", Price=10.0m, RestaurantId=restaurants[4].RestaurantId }
            };

            foreach (var m in menuItems)
                await service.CreateMenuItemAsync(m);

            var reservations = new List<Reservation>
            {
                new Reservation { CustomerId=customers[0].CustomerId, RestaurantId=restaurants[0].RestaurantId, TableId=1, ReservationDate=DateTime.Now.AddDays(1), PartySize=2 },
                new Reservation { CustomerId=customers[1].CustomerId, RestaurantId=restaurants[1].RestaurantId, TableId=1, ReservationDate=DateTime.Now.AddDays(2), PartySize=4 },
                new Reservation { CustomerId=customers[2].CustomerId, RestaurantId=restaurants[2].RestaurantId, TableId=1, ReservationDate=DateTime.Now.AddDays(1), PartySize=3 },
                new Reservation { CustomerId=customers[3].CustomerId, RestaurantId=restaurants[3].RestaurantId, TableId=1, ReservationDate=DateTime.Now.AddDays(3), PartySize=2 },
                new Reservation { CustomerId=customers[4].CustomerId, RestaurantId=restaurants[4].RestaurantId, TableId=1, ReservationDate=DateTime.Now.AddDays(4), PartySize=5 }
            };

            foreach (var r in reservations)
                await service.CreateReservationAsync(r);

            foreach (var res in reservations)
            {
                var order = await service.CreateOrderAsync(new Order
                {
                    ReservationId = res.ReservationId,
                    EmployeeId = employees[0].EmployeeId,
                    OrderDate = DateTime.Now,
                    TotalAmount = 20.0m
                });

                await service.CreateOrderItemAsync(new OrderItem
                {
                    OrderId = order.OrderId,
                    ItemId = menuItems[0].ItemId,
                    Quantity = 2,
                    Price = menuItems[0].Price
                });
            }
        }

        public static async Task Demo(RestaurantReservationServiceGet service)
        {
            Console.WriteLine("Testing Get methods...");

            var managers = await service.ListManagersAsync();
            Console.WriteLine($"Managers: {managers.Count}");

            var reservations = await service.GetReservationsByCustomerAsync(1);
            Console.WriteLine($"Reservations for Customer 1: {reservations.Count}");

            var orders = await service.ListOrdersAndMenuItemsAsync(1);
            Console.WriteLine($"Orders for Reservation 1: {orders.Count}");

            var menuItems = await service.ListOrderedMenuItemsAsync(1);
            Console.WriteLine($"Menu Items for Reservation 1: {menuItems.Count}");

            var avgOrderAmount = await service.CalculateAverageOrderAmountAsync(1);
            Console.WriteLine($"Average Order Amount for Employee 1: {avgOrderAmount}");
        }
    }
}
