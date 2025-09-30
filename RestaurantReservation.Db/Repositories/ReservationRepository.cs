using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        public ReservationRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<ReservationWithDetails>> GetReservationsWithDetailsAsync()
        {
            return await _context.Set<ReservationWithDetails>()
                .FromSqlRaw("SELECT * FROM vw_ReservationsWithDetails")
                .ToListAsync();
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _context.OrderItems
                .Where(oi => oi.Order.ReservationId == reservationId)
                .Select(oi => oi.MenuItem)
                .Distinct()
                .ToListAsync();
        }
    }
}
