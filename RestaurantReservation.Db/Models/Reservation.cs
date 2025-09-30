using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Reservation
    {
        [Key]
        [Column("reservation_id")]
        public int ReservationId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("Restaurant")]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [ForeignKey("Table")]
        [Column("table_id")]
        public int TableId { get; set; }

        [Required]
        [Column("reservation_date")]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Column("party_size")]
        public int PartySize { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
