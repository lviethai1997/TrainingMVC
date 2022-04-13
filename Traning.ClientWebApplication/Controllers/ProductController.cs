using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Traning.ClientWebApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            return View();
        }

    }
}
