using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Training.ViewModel.Catalog.CartModel
{
    public class ViewCartRequest
    {
        [Display(Name = "Hình ảnh")]
        [Description("Hình ảnh")]
        public string Images { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Description("Tên sản phẩm")]
        public string productName { get; set; }
        [Display(Name = "Mã sản phẩm")]
        [Description("Mã sản phẩm")]
        public int productId { get; set; }
        [Display(Name = "Số lượng mua")]
        [Description("Số lượng mua")]
        public int quantityProduct { get; set; }
        [Display(Name = "Giá sản phẩm")]
        [Description("Giá sản phẩm")]
        public decimal priceProduct { get; set; }
        [Display(Name = "Giảm giá")]
        [Description("Giảm giá")]
        public decimal Sale { get; set; }
        [Display(Name = "Giá đã giảm")]
        [Description("Giá đã giảm")]
        public decimal priceSaleProduct { get; set; }
    }
}