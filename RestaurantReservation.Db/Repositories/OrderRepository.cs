using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<Order>> GetByReservationIdAsync(int reservationId)
        {
            return await _dbSet.Where(o => o.ReservationId == reservationId).ToListAsync();
        }
        
        public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }
    }
}
