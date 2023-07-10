using IsDomasna.IsDomasna.Domain.Models;
using IsDomasna.Repository;
using IsDomasna.Repository.YourAppName.Data.Repositories;

namespace IsDomasna.IsDomasna.Service.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAllTickets();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.AddTicket(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.UpdateTicket(ticket);
        }

        public void DeleteTicket(int id)
        {
            _ticketRepository.DeleteTicket(id);
        }
    }
}
