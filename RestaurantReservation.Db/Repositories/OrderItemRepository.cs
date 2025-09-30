using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>
    {
        public OrderItemRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<OrderItem>> GetByOrderIdAsync(int orderId)
        {
            return await _dbSet.Where(oi => oi.OrderId == orderId).ToListAsync();
        }
    }
}
