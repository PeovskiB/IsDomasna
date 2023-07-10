using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IsDomasna.Models;
using IsDomasna.Data;
using Microsoft.EntityFrameworkCore;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace IsDomasna.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Order/Create
        [Authorize]
        public IActionResult Create()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var order = new Order
            {
                UserId = user.Id,
                OrderDate = DateTime.Now
            };

            var shoppingCartItems = _context.ShoppingCartItems
                .Where(item => item.ShoppingCart.UserId == user.Id)
                .ToList();

            foreach (var item in shoppingCartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    TicketId = item.TicketId,
                    Ticket = item.Ticket
                });
            }

            _context.Orders.Add(order);
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        // GET: /Order/Orders
        public IActionResult Orders()
        {
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Ticket)
                .ToList();

            return View(orders);
        }

        // POST: /Order/GenerateReport
        [HttpPost]
        public IActionResult GenerateReport(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Ticket)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            // Generate the PDF report for the order
            using (MemoryStream stream = new MemoryStream())
            {
                // Create the PDF document
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Add the order details to the PDF
                Paragraph heading = new Paragraph("Order Details");
                document.Add(heading);

                // Order ID
                Paragraph orderIdParagraph = new Paragraph($"Order ID: {order.OrderId}");
                document.Add(orderIdParagraph);

                // User ID
                Paragraph userIdParagraph = new Paragraph($"User ID: {order.UserId}");
                document.Add(userIdParagraph);

                // Order Date
                Paragraph orderDateParagraph = new Paragraph($"Order Date: {order.OrderDate}");
                document.Add(orderDateParagraph);

                // Order Items
                Paragraph orderItemsHeading = new Paragraph("Order Items:");
                document.Add(orderItemsHeading);

                foreach (var item in order.OrderItems)
                {
                    Paragraph itemParagraph = new Paragraph($"- {item.Ticket.Title}");
                    document.Add(itemParagraph);
                }

                document.Close();

                // Return the PDF file
                return File(stream.ToArray(), "application/pdf", "OrderReport.pdf");
            }
        }

    }
}
