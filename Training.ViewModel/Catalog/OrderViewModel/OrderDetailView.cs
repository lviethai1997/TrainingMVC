using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Training.ViewModel.Catalog.CartModel;

namespace Training.ViewModel.Catalog.OrderViewModel
{
    public class OrderDetailView
    {
        [Display(Name ="Tên khách hàng")]
        public string CustommerName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string CustommerPhone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string CustommerAddress { get; set; }
        [Display(Name = "Email")]
        public string CustommerEmail { get; set; }
        [Display(Name = "Tổng số sản phẩm")]
        public int TotalQty { get; set; }
        [Display(Name = "Giá trị đơn hàng")]
        public decimal TotalAmount { get; set; }

        public int OrderId { get; set; }

        public List<ViewCartRequest> ListProducts { get; set; }
    }
}