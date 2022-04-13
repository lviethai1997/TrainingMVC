using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.ViewModel.Common;

namespace Training.AdminWebApplication.Controllers.Component
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
