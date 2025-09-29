using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        [Key]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(255)]
        [Column("address")]
        public string Address { get; set; }

        [StringLength(20)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Column("opening_hours")]
        public string OpeningHours { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
