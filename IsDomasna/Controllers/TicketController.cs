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

        // GET: /
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

        // GET: /Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: /Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Tickets.Update(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: /Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: /Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
