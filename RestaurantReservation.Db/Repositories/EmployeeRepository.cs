using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _dbSet.Where(e => e.Position == "Manager").ToListAsync();
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var orders = await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .ToListAsync();

            if (!orders.Any()) return 0;
            return orders.Average(o => o.TotalAmount);
        }

        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurantAsync()
        {
            return await _context.Set<EmployeeWithRestaurant>()
                .FromSqlRaw("SELECT * FROM vw_EmployeesWithRestaurant")
                .ToListAsync();
        }
    }
}
