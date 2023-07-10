using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IsDomasna.Models;
using IsDomasna.Data;
using Microsoft.EntityFrameworkCore;

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


    }
}
