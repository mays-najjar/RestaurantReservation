using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class MenuItem
    {
        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }

        [ForeignKey(nameof(Restaurant))]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(200)] 
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
