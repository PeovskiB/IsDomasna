using IsDomasna.Models;
using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public CinemaUser User { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}