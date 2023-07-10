using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsDomasna.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Validity Date")]
        [DataType(DataType.Date)]
        public DateTime ValidityDate { get; set; }

        public string? Genre { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }

}
