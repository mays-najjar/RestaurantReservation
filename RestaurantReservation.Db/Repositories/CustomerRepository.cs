using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
      public class CustomerRepository: BaseRepository<Customer>
    {
        public CustomerRepository(RestaurantReservationDbContext context) : base(context) { }

        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int partySize)
{
    var param = new SqlParameter("@MinPartySize", partySize);

    return await _context.Customers
        .FromSqlRaw("EXEC dbo.GetCustomersByPartySize @MinPartySize", param)
        .ToListAsync();
}
    }
}