using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantReservationServiceGet 
    {
         private readonly RestaurantReservationDbContext _context;
        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _context.Employees
                .Where(e => e.Position == "Manager")
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)    
                    .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.ReservationId == reservationId)
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

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var orders = await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .ToListAsync();

            if (!orders.Any())
                return 0m;
                
            return orders.Average(o => o.TotalAmount); 
        }
    }
}
