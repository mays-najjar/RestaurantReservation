using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<decimal> CalculateTotalRevenueAsync(int restaurantId)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT dbo.CalculateTotalRevenue(@restaurantId)";
            command.Parameters.Add(new SqlParameter("@restaurantId", restaurantId));
            var result = await command.ExecuteScalarAsync();
            return result != null ? (decimal)result : 0;
        }
    }
}
