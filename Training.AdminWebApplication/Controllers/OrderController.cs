using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.OrderService;
using Training.ViewModel.Common;

namespace Training.AdminWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly INotyfService _notyfService;

        public OrderController(IOrder order, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _order = order;
        }

        [Route("orderList", Name = "orderList")]
        public async Task<ActionResult> Index(int pageIndex = 1, int pageSize = 10, string keyword = null)
        {
            var request = new PagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };

            var listOrder = await _order.listOrder(request);
            return View(listOrder);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _order.OrderDetail(id);
            return View(result);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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