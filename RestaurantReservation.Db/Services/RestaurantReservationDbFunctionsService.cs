using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DbFunctions;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantReservationDbFunctionsService
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantReservationDbFunctionsService(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalRevenueAsync(int restaurantId)
        {
            return await _context.Orders
                .Select(o => RestaurantDbFunctions.CalculateTotalRevenue(restaurantId))
                .FirstAsync();
        }
    }
}
