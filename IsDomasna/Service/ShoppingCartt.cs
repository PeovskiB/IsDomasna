//using IsDomasna.Data;
//using IsDomasna.Models;
//using System.Threading.Tasks;

//namespace IsDomasna.Services
//{
//    public interface IShoppingCartService
//    {
//        Task<ShoppingCart> GetShoppingCartAsync();
//        Task AddItemToCartAsync(int ticketId);
//        Task RemoveItemFromCartAsync(int shoppingCartItemId);
//        Task ClearCartAsync();
//    }

//    public class ShoppingCartService : IShoppingCartService
//    {
//        private readonly ApplicationDbContext _context;

//        public ShoppingCartService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ShoppingCart> GetShoppingCartAsync()
//        {
//            // Implement logic to retrieve the shopping cart for the current user
//            // You can access the current user using HttpContext.User property
//            // and retrieve the corresponding shopping cart from the database

//            // Example implementation:
//            var user = await _context.Users.FindAsync(userId);
//            var cart = user?.ShoppingCart;

//            return cart;
//        }

//        public async Task AddItemToCartAsync(int ticketId)
//        {
//            // Implement logic to add an item to the shopping cart
//            // You can retrieve the ticket from the database based on the provided ticketId
//            // and associate it with the current user's shopping cart

//            // Example implementation:
//            var ticket = await _context.Tickets.FindAsync(ticketId);
//            var user = await _context.Users.FindAsync(userId);
//            var cart = user?.ShoppingCart;

//            if (ticket != null && cart != null)
//            {
//                var item = new ShoppingCartItem
//                {
//                    Ticket = ticket,
//                    ShoppingCart = cart
//                };

//                _context.ShoppingCartItems.Add(item);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task RemoveItemFromCartAsync(int shoppingCartItemId)
//        {
//            // Implement logic to remove an item from the shopping cart
//            // You can retrieve the item from the database based on the provided shoppingCartItemId
//            // and remove it from the shopping cart

//            // Example implementation:
//            var item = await _context.ShoppingCartItems.FindAsync(shoppingCartItemId);

//            if (item != null)
//            {
//                _context.ShoppingCartItems.Remove(item);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task ClearCartAsync()
//        {
//            // Implement logic to clear the shopping cart
//            // You can retrieve the current user's shopping cart and remove all items from it

//            // Example implementation:
//            var user = await _context.Users.FindAsync(userId);
//            var cart = user?.ShoppingCart;

//            if (cart != null)
//            {
//                cart.ShoppingCartItems.Clear();
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
