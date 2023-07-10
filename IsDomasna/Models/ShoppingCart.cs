using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        public string UserId { get; set; }

        public CinemaUser Owner { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}


