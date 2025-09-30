using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
    {
        public RestaurantReservationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RestaurantReservationDbContext(optionsBuilder.Options);
        }
    }
}
