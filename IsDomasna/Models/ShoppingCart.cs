using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models
{
    public class ShoppingCart

    {
        [Key]
        public int CartId { get; set; }

        public string? OwnerId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }

}
