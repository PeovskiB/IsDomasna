namespace IsDomasna.Repository
{
    using System.Collections.Generic;
    using IsDomasna.Domain.Models;

    namespace YourAppName.Data.Repositories
    {
        public interface ITicketRepository
        {
            IEnumerable<Ticket> GetAllTickets();
            Ticket GetTicketById(int id);
            void AddTicket(Ticket ticket);
            void UpdateTicket(Ticket ticket);
            void DeleteTicket(int id);
        }
    }

}
