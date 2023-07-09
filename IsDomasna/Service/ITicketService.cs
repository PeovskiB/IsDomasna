using IsDomasna.Models;

namespace IsDomasna.Service
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
    }

}
