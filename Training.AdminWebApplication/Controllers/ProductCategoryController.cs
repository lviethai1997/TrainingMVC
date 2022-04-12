using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductCategoryService;
using Training.ViewModel.Catalog.ProductCategoryModel;

namespace Training.AdminWebApplication.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategory _productCategory;
        private readonly INotyfService _notyfService;

        public ProductCategoryController(IProductCategory productCategory, INotyfService notyfService)
        {
            _productCategory = productCategory;
            _notyfService = notyfService;
        }

        // GET: ProductCategoryController
        [Route("ListProCate", Name = "ListProCate")]
        public async Task<IActionResult> Index()
        {
            var allPc = await _productCategory.GetAllProductCategories();

            return View(allPc);
        }

        // GET: ProductCategoryController/Create
        [Route("/CreateProCate", Name = "CreateProCate")]
        public async Task<IActionResult> Create()
        {
            ViewBag.DrProCat = await GetNameParentId();
            return View();
        }

        [Route("/CreateProCate", Name = "CreateProCate")]
        // POST: ProductCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductCategoryRequest collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                ViewBag.DrProCat = await GetNameParentId();
                var create = await _productCategory.CreateProductCategory(collection);

                if (create.IsSuccess == true)
                {
                    _notyfService.Success(create.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Error(create.Message);
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategoryController/Edit/5
        [Route("/EditProCate.{id}", Name = "EditProCate")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.DrProCat = await GetNameParentId();
            var Procate = await _productCategory.GetById(id);

            if (Procate == null)
            {
                _notyfService.Error("Không tồn tại danh mục này!");
                return RedirectToAction("Index");
            }

            var result = new UpdateProductCategoryRequest()
            {
                Name = Procate.Name,
                SaleCate = Procate.SaleCate,
                ParentId = Procate.ParentId,
                Banner = Procate.Banner,
                Show = Procate.Show,
                Status = Procate.Status,
                Updated_time = DateTime.Now
            };

            return View(result);
        }

        // POST: ProductCategoryController/Edit/5
        [Route("/EditProCate.{id}", Name = "EditProCate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductCategoryRequest collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                ViewBag.DrProCat = await GetNameParentId();
                var update = await _productCategory.UpdateProductCategory(id, collection);

                if (update.IsSuccess == true)
                {
                    _notyfService.Success(update.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Error(update.Message);
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [Route("/HomeProCate/{id}", Name = "HomeProCate")]
        public async Task<IActionResult> HomeProCate(int id)
        {
            var result = await _productCategory.ShowAtHome(id);

            if (result.IsSuccess == true)
            {
                _notyfService.Success(result.Message);
            }
            else
            {
                _notyfService.Error(result.Message);
            }

            return RedirectToAction("Index");
        }

        [Route("/HideProCate/{id}", Name = "HideProCate")]
        public async Task<IActionResult> HideProCate(int id)
        {
            var result = await _productCategory.HideProductCategory(id);

            if (result.IsSuccess == true)
            {
                _notyfService.Success(result.Message);
            }
            else
            {
                _notyfService.Error(result.Message);
            }

            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<object>> GetNameParentId()
        {
            List<object> result = new List<object>();
            var ProCate = await _productCategory.GetAllProductCategories();

            result.Add(new { value = 0, name = "Danh Mục Cha" });
            foreach (var item in ProCate.Items)
            {
                result.Add(new { value = item.Id, name = item.Name });
            }

            return result;
        }
    }
}