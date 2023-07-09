namespace IsDomasna.Models.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidityDate { get; set; }
        public string? Genre { get; set;}
    }


}
