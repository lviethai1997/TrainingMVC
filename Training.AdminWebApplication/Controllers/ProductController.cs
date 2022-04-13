using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductCategoryService;
using Training.Service.Catalog.ProductService;
using Training.ViewModel.Catalog.ProductModel;

namespace Training.AdminWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly INotyfService _notyfService;
        private readonly IProductCategory _productCategory;

        public ProductController(IProduct product, INotyfService notyfService, IProductCategory productCategory)
        {
            _notyfService = notyfService;
            _product = product;
            _productCategory = productCategory;
        }

        // GET: ProductController
        [Route("/productList", Name = "productList")]
        public async Task<ActionResult> Index()
        {
            ViewBag.procate = LoadProCate();
            var products = await _product.GetAll();
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
            ViewBag.procate = await LoadProCate();
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
                ViewBag.procate = await LoadProCate();
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
            ViewBag.procate = await LoadProCate();
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
                ShowImages = findById.Images,
                ShowThunbar = findById.Thunbar,
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
                ViewBag.procate = await LoadProCate();
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
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _product.FindById(id);

            var result = new UpdateProductRequest()
            {
                Name = product.Name,
                Price = product.Price,
                ShowThunbar = product.Thunbar,
                ShowImages = product.Images,
                PriceIn = product.PriceIn,
                Quantity = product.Quantity,
                Status = product.Status,
                Created_time = product.Created_time,
                Updated_time = product.Updated_time,
            };
            return View(result);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }

                var delProduct = await _product.DeleteProduct(id);

                if (delProduct.IsSuccess == true)
                {
                    _notyfService.Success(delProduct.Message);
                }
                else
                {
                    _notyfService.Error(delProduct.Message);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<List<object>> LoadProCate()
        {
            var procate = await _productCategory.GetAllProductCategories();

            List<object> listProcate = new List<object>();

            foreach (var proc in procate.Items)
            {
                listProcate.Add(new { value = proc.Id, name = proc.Name });
            }

            return listProcate;
        }
    }
}