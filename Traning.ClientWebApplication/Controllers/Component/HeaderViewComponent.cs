using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.CartService;
using Training.Service.Catalog.ProductCategoryService;

namespace Traning.ClientWebApplication.Controllers.Component
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IProductCategory _productCategory;
        private readonly ICart _cart;

        public HeaderViewComponent(IProductCategory productCategory,ICart cart)
        {
            _productCategory = productCategory;
            _cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategories = await _productCategory.GetCateClient();
            ViewBag.CartItem = await _cart.GetCarts(4);

            return View(productCategories);
        }
    }
}
