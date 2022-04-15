using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.CartService;
using Training.ViewModel.Catalog.CartModel;

namespace Traning.ClientWebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private readonly INotyfService _notyfService;

        public CartController(ICart cart, INotyfService notyfService)
        {
            _cart = cart;
            _notyfService = notyfService;
        }

        [Route("gio-hang", Name = "GioHang")]
        public async Task<IActionResult> Index()
        {
            var carts = await _cart.GetCarts(1);
            return View(carts);
        }


        public async Task<IActionResult> AddtoCart([FromQuery] int productId, [FromQuery] int quantity)
        {
            var request = new AddCartRequest()
            {
                productId = productId,
                productQuantity = quantity,
                userId = 1
            };

            var addCart = await _cart.AddToCart(request);

            if (addCart.IsSuccess == true)
            {
                _notyfService.Success(addCart.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(addCart.Message);
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditCart(EditCartRequest request)
        {
            var UpdateCart = await _cart.EditToCart(request);
            if (UpdateCart.IsSuccess == true)
            {
                _notyfService.Success(UpdateCart.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(UpdateCart.Message);
                return RedirectToAction("Index");
            }
        }

        [Route("/delProductInCart/{productId}")]
        public async Task<IActionResult> DeleteCart(int productId)
        {
            var delProductInCart = await _cart.DeleteProductInCart(productId, 1);
            if (delProductInCart.IsSuccess == true)
            {
                _notyfService.Success(delProductInCart.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(delProductInCart.Message);
                return RedirectToAction("Index");
            }

        }
    }
}