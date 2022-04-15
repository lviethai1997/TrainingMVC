using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductCategoryService;

namespace Traning.ClientWebApplication.Controllers.Component
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IProductCategory _productCategory;

        public HeaderViewComponent(IProductCategory productCategory)
        {
            _productCategory = productCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategories = await _productCategory.GetCateClient();

            return View(productCategories);
        }
    }
}
