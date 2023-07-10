using IsDomasna.IsDomasna.Domain.Models;

namespace IsDomasna.IsDomasna.Service.Service
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
