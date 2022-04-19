using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Training.Service.Catalog.OrderService;
using Training.Service.Common;
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

        [HttpGet]
        public async Task<IActionResult> PrintExcel(int id)
        {
            string fileName = string.Concat("Don_hang_" + id + "_" + DateTime.Now.ToString("yyyyMMddHHss") + ".xlsx");
            string folderReport = System.AppDomain.CurrentDomain.BaseDirectory + @"Excels\";
            if (!Directory.Exists(folderReport))
            {
                Directory.CreateDirectory(folderReport);
            }
            string fullpath = Path.Combine(folderReport, fileName);

            try
            {
                var data = await _order.OrderDetail(id);
                var excel = await PrintBillExcel.ExportExcel(data, fullpath);
                return File(excel, "application/vnd.ms-excel", fileName);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}