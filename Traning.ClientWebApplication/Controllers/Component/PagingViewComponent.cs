using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traning.ClientWebApplication.Controllers.Component
{
    public class PagingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
