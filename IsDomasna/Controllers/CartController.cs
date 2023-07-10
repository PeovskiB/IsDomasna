//using IsDomasna.Models;
//using IsDomasna.Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace YourAppName.Controllers
//{
//    public class CartController : Controller
//    {
//        private readonly ITicket _shoppingCartService;

//        public CartController(IShoppingCartService shoppingCartService)
//        {
//            _shoppingCartService = shoppingCartService;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var cart = await _shoppingCartService.GetShoppingCartAsync();
//            return View(cart);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> RemoveFromCart(int shoppingCartItemId)
//        {
//            await _shoppingCartService.RemoveItemFromCartAsync(shoppingCartItemId);
//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ClearCart()
//        {
//            await _shoppingCartService.ClearCartAsync();
//            return RedirectToAction("Index");
//        }
//    }
//}
