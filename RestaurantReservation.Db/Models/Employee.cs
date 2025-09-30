using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Employee
    {
        [Key]
        [Column("employee_id")] 
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("position")]
        public string Position { get; set; }

        [ForeignKey(nameof(Restaurant))]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
