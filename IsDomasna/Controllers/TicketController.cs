using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IsDomasna.Models; // Update with the appropriate namespace for your models
using IsDomasna.Data; // Update with the appropriate namespace for your data context
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace YourAppName.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CinemaUser> _userManager;

        public TicketController(ApplicationDbContext context, UserManager<CinemaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /
        [Authorize]
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
            if (id != ticket.TicketId)
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

        // GET: /Export
        public IActionResult Export(string genre)
        {
            var tickets = _context.Tickets.ToList();

            // Filter the tickets based on the selected genre
            if (!string.IsNullOrEmpty(genre))
            {
                tickets = tickets.Where(t => t.Genre == genre).ToList();
            }

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet
                var worksheet = package.Workbook.Worksheets.Add("Tickets");

                // Set the header row
                worksheet.Cells[1, 1].Value = "Title";
                worksheet.Cells[1, 2].Value = "Price";
                worksheet.Cells[1, 3].Value = "Validity Date";
                worksheet.Cells[1, 4].Value = "Genre";

                // Populate the data rows
                for (int i = 0; i < tickets.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = tickets[i].Title;
                    worksheet.Cells[i + 2, 2].Value = tickets[i].Price;
                    worksheet.Cells[i + 2, 3].Value = tickets[i].ValidityDate.ToShortDateString();
                    worksheet.Cells[i + 2, 4].Value = tickets[i].Genre;
                }

                // Auto-fit the columns
                worksheet.Cells.AutoFitColumns();

                // Generate a unique filename for the Excel file
                var fileName = $"Tickets_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

                // Save the Excel file to a stream
                var stream = new MemoryStream(package.GetAsByteArray());

                // Return the file as a response
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        public async Task<IActionResult> AddToCart(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users
                .Include(u => u.ShoppingCart)
                    .ThenInclude(sc => sc.ShoppingCartItems)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return Unauthorized();
            }

            var shoppingCartItem = new ShoppingCartItem
            {
                TicketId = ticket.TicketId,
                ShoppingCartId = user.ShoppingCart.CartId
            };

            user.ShoppingCart.ShoppingCartItems.Add(shoppingCartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart");
        }

        // GET: /Cart
        [Authorize]
        public IActionResult Cart(DateTime? validityDate)
        {
            var cart = GetShoppingCart();

            var tickets = cart.ShoppingCartItems
                .Select(item => item.Ticket)
                .AsQueryable();

            // Apply the validity date filter if provided
            if (validityDate.HasValue)
            {
                tickets = tickets.Where(t => t.ValidityDate.Date == validityDate.Value.Date);
            }

            return View(tickets.ToList());
        }

        private ShoppingCart GetShoppingCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users
                .Include(u => u.ShoppingCart)
                .ThenInclude(cart => cart.ShoppingCartItems)
                .ThenInclude(item => item.Ticket)
                .FirstOrDefault(u => u.Id == userId);

            return user?.ShoppingCart;
        }



    }
}
