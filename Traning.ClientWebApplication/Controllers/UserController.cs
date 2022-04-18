using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Traning.ClientWebApplication.Controllers
{
    public class UserController : Controller
    {
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
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
