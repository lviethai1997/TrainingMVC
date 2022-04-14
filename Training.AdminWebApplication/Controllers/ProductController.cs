using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductCategoryService;
using Training.Service.Catalog.ProductService;
using Training.ViewModel.Catalog.ProductModel;
using Training.ViewModel.Common;
using System.Linq;

namespace Training.AdminWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly IProductCategory _productCategory;
        private readonly INotyfService _notyfService;

        public ProductController(IProduct product, INotyfService notyfService, IProductCategory productCategory)
        {
            _notyfService = notyfService;
            _productCategory = productCategory;
            _product = product;
        }

        // GET: ProductController
        [Route("/productList", Name = "productList")]
        public async Task<ActionResult> Index(int pageIndex = 1, int pageSize = 10, string keyword = null, int? idCate = null)
        {

            var getListProCate = await _productCategory.GetAllProductCategories();

            ViewBag.listProCat = getListProCate.Items.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = idCate.HasValue && idCate.Value.ToString() == x.Id.ToString()
            });

            ViewBag.keyword = keyword;

            var request = new PagingRequest()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Keyword = keyword,
                idCate = idCate
            };

            var products = await _product.GetAllPaging(request);
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [Route("/CreateProduct", Name = "CreateProduct")]
        public async Task<ActionResult> Create()
        {
            ViewBag.listProCat = await ListProCate();
            return View();
        }

        // POST: ProductController/Create
        [Route("/CreateProduct", Name = "CreateProduct")]
        [Consumes("multipart/form-data")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateProductRequest collection)
        {
            try
            {
                ViewBag.listProCat = await ListProCate();
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var Create = await _product.CreateProduct(collection);

                if (Create.IsSuccess == true)
                {
                    _notyfService.Success(Create.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Error(Create.Message);
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        [Route("/EditProduct.{id}", Name = "EditProduct")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.listProCat = await ListProCate();
            var findById = await _product.FindById(id);

            var product = new UpdateProductRequest()
            {
                CategoryId = findById.CategoryId,
                Name = findById.Name,
                Price = findById.Price,
                PriceIn = findById.PriceIn,
                Sale = findById.Sale,
                Content = findById.Content,
                Quantity = findById.Quantity,
                Hot = findById.Hot,
                Status = findById.Status,
                ThunbarNow = findById.Thunbar,
                ImagesNow = findById.Images
            };

            return View(product);
        }

        // POST: ProductController/Edit/5
        [Route("/EditProduct.{id}", Name = "EditProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Edit(int id, [FromForm] UpdateProductRequest collection)
        {
            try
            {
                ViewBag.listProCat = await ListProCate();
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var Update = await _product.UpdateProduct(id, collection);

                if (Update.IsSuccess == true)
                {
                    _notyfService.Success(Update.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Error(Update.Message);
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<IEnumerable<object>> ListProCate()
        {
            var procates = await _productCategory.GetAllProductCategories();

            List<object> list = new List<object>();
            foreach (var item in procates.Items)
            {
                list.Add(new { value = item.Id, name = item.Name });
            }

            return list;
        }
    }
}