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
            var carts = await _cart.GetCarts(4);
            return View(carts);
        }

        [Route("checkout", Name = "checkout")]
        public async Task<IActionResult> Checkout()
        {
            var getInfor = await _cart.GetInfoUser(4);
            return View(getInfor);
        }

        [Route("checkout", Name = "checkout")]
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckOutRequest request)
        {
            request.UserId = 4;
            var ConfirmOrder = await _cart.CheckOut(request);
            if (ConfirmOrder.IsSuccess == true)
            {
                _notyfService.Success(ConfirmOrder.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(ConfirmOrder.Message);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> AddtoCart(int productId, int quantity)
        {
            var request = new AddCartRequest()
            {
                productId = productId,
                productQuantity = quantity,
                userId = 4
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

        [Route("updateCart", Name = "updateCart")]
        [HttpPost]
        public async Task<IActionResult> EditCart(int productId, int quantity)
        {
            var UpdateCart = await _cart.EditToCart(productId, quantity, 4);
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
            var delProductInCart = await _cart.DeleteProductInCart(productId, 4);
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