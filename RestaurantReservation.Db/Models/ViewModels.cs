using System;

namespace RestaurantReservation.Db.Models
{
    public class ReservationWithDetails
    {
        public int ReservationId  { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
    }

    public class EmployeeWithRestaurant
    {
        public int EmployeeId  { get; set; }
        public string FirstName  { get; set; }
        public string LastName  { get; set; }
        public string Position { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
    }
}
