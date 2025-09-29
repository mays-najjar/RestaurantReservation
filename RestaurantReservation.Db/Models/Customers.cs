using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Customer
    {
        [Key]
        [Column("customer_id")] 
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
