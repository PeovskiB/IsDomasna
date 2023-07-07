using IsDomasna.Data;
using IsDomasna.Models;
using IsDomasna.Repository.YourAppName.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsDomasna.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DbSet<Ticket> Tickets;


        public TicketRepository(ApplicationDbContext context)
        {
            // Initialize placeholder tickets
            Tickets.AddRange(new[]
            {
            new Ticket { Id = 1, Title = "Ticket 1", Price = 10.99m, ValidityDate = new DateTime(2023, 7, 1) },
            new Ticket { Id = 2, Title = "Ticket 2", Price = 15.99m, ValidityDate = new DateTime(2023, 7, 2) },
            new Ticket { Id = 3, Title = "Ticket 3", Price = 12.99m, ValidityDate = new DateTime(2023, 7, 3) },
            // Add more placeholder tickets as needed
        
            });
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return Tickets;
        }

        public Ticket GetTicketById(int id)
        {
            return Tickets.FirstOrDefault(t => t.Id == id);
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            var existingTicket = Tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (existingTicket != null)
            {
                existingTicket.Title = ticket.Title;
                existingTicket.Price = ticket.Price;
                existingTicket.ValidityDate = ticket.ValidityDate;
            }
        }

        public void DeleteTicket(int id)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                Tickets.Remove(ticket);
            }
        }
    }

}
