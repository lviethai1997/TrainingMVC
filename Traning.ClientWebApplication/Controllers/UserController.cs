using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Traning.ClientWebApplication.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(int id)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult EditInformation(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInformation(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
