using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductService;
using Training.ViewModel.Common;
using System.Linq;
using Training.ViewModel.Catalog.ProductModel;

namespace Traning.ClientWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [Route("/Category-{Name}/{CateId}")]
        public async Task<IActionResult> ProductList(int CateId, int pageIndex = 1, int pageSize = 10, string keyword = null, int? idCate = null)
        {
            var request = new PagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword,
                idCate = idCate
            };

            var products = await _product.GetProductByCategory(CateId, request);

            return View(products);
        }

        [Route("/chi-tiet-san-pham/{Name}/{Id}")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _product.FindById(id);
            return View(product);
        }
    }
}