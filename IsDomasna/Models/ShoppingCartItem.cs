using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
