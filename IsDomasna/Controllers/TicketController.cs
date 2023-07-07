using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IsDomasna.Models; // Update with the appropriate namespace for your models
using IsDomasna.Data; // Update with the appropriate namespace for your data context

namespace YourAppName.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public IActionResult Index(DateTime? validityDate)
        {
            var tickets = _context.Tickets.AsQueryable();

            // Apply the validity date filter if provided
            if (validityDate.HasValue)
            {
                tickets = tickets.Where(t => t.ValidityDate.Date == validityDate.Value.Date);
            }

            return View(tickets.ToList());
        }
    }
}
