using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>
    {
        public MenuItemRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<MenuItem>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _dbSet.Where(m => m.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
