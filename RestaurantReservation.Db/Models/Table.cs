using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Tables")]
    public class Table
    {
        [Key]
        [Column("table_id")]
        public int TableId { get; set; }

        [ForeignKey("Restaurant")]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Required]
        [Column("capacity")]
        public int Capacity { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
