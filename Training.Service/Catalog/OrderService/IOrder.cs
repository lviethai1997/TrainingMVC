using System.Threading.Tasks;
using Training.ViewModel.Catalog.OrderViewModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.OrderService
{
    public interface IOrder
    {
        Task<PageResult<ListOrderView>> listOrder(PagingRequest request);

        Task<PageActionResult> ConfirmOrder(int OrderId);

        Task<PageActionResult> CancelOrder(int OrderId);

        Task<OrderDetailView> OrderDetail(int OrderId);

        Task<OrderDetailView> PrintBill(int OrderId);
    }
}