using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traning.ClientWebApplication.Controllers.Component
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
