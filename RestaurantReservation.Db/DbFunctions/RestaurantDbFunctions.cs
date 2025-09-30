using Microsoft.EntityFrameworkCore;
using System;

namespace RestaurantReservation.Db.DbFunctions
{
    public static class RestaurantDbFunctions
    {
        [DbFunction("CalculateTotalRevenue", "dbo")]
        public static decimal CalculateTotalRevenue(int restaurantId)
        {
            throw new NotSupportedException();
        }
    }
}
