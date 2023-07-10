using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsDomasna.IsDomasna.Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Validity Date")]
        [DataType(DataType.Date)]
        public DateTime ValidityDate { get; set; }
    }

}
