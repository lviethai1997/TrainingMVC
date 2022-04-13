using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductService;
using Training.ViewModel.Catalog.ProductModel;
using Training.ViewModel.Common;

namespace Training.AdminWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly INotyfService _notyfService;

        public ProductController(IProduct product, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _product = product;
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
        [Route("/CreateProduct",Name = "CreateProduct")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [Route("/CreateProduct", Name = "CreateProduct")]
        [Consumes("multipart/form-data")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]CreateProductRequest collection)
        {
            try
            {
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
    }
}