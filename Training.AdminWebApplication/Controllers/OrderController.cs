using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        [Route("exportExcel")]
        public async Task<IActionResult> PrintExcel()
        {
            try
            {
                byte[] bytes = await Models.TempData.ExcelByte;
                return File(bytes, "application/vnd.ms-excel", Models.TempData.fileName);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("reviewExcel", Name = "reviewExcel")]
        public async Task<JsonResult> reviewExcel(int id)
        {
            string fileName = string.Concat("Don_hang_" + id + "_" + DateTime.Now.ToString("yyyyMMddHHss") + ".xlsx");
            string folderReport = System.AppDomain.CurrentDomain.BaseDirectory + @"Excels\";

            //set resource file(right click to file and change buid action to 'Embedded resource' ) and conver it to stream
            string resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .Single(str => str.EndsWith("av6.png"));
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            ////////////////////////
            if (!Directory.Exists(folderReport))
            {
                Directory.CreateDirectory(folderReport);
            }
            string fullpath = Path.Combine(folderReport, fileName);

            //DirectoryInfo d = new DirectoryInfo(folderReport);
            //FileInfo[] Files = d.GetFiles("*.xlsx");
            //foreach (FileInfo file in Files)
            //{
            //    file.Delete();
            //}

            var data = await _order.OrderDetail(id);
            var excel = await PrintBillExcel.ExportExcel(data, fullpath, stream);

            Models.TempData.ExcelByte = excel[0];
            Models.TempData.fileName = fileName;

            var obj = new List<object>();
            obj.Add(new { html = excel[1], css = excel[2] });

            return Json(obj);
        }
    }
}