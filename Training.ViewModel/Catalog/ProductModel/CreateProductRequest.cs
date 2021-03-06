using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Training.ViewModel.Catalog.ProductModel
{
    public class CreateProductRequest
    {
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Display(Name = "Giá nhập")]
        public decimal PriceIn { get; set; }

        [Display(Name = "Khuyến mãi")]
        public decimal Sale { get; set; }

        [Display(Name = "Thunbar")]
        [Required]
        public IFormFile Thunbar { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Tồn kho")]
        public int Quantity { get; set; }

        [Display(Name = "Sản phẩm HOT")]
        public int Hot { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}