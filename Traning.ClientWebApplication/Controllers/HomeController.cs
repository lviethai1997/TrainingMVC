using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Training.Service.Catalog.ProductService;
using Traning.ClientWebApplication.Models;

namespace Traning.ClientWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _product;

        public HomeController(ILogger<HomeController> logger, IProduct product)
        {
            _product = product;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var getData = await _product.GetIndexClientProducts();
            return View(getData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}