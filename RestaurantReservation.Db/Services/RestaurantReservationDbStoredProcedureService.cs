using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantReservationDbStoredProcedureService
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantReservationDbStoredProcedureService(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize)
        {
            return await _context.Customers
                .FromSqlRaw("EXEC dbo.GetCustomersByPartySize @MinPartySize = {0}", minPartySize)
                .ToListAsync();
        }
    }
}