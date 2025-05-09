using Ecom.Data.Cart;
using Ecom.Data.Services;
using Ecom.Data.ViewModels;
using eTickets.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecom.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IMoviesService _service;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IMoviesService service, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _service = service;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
         }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId, userRole);
            return View(orders);
        }
        [Authorize]
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        [Authorize]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _service.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("ShoppingCart");
        }

        [Authorize]
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _service.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction("ShoppingCart");
        }

        [Authorize]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }

    }
}
