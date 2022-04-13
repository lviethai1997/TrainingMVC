﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Training.ViewModel.Catalog.ProductModel
{
    public class UpdateProductRequest
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
        public IFormFile Thunbar { get; set; }

        [Display(Name = "Hình ảnh")]
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

        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        [Display(Name="Hình ảnh đang đại diện")]
        public string? ShowThunbar { get; set; }
        [Display(Name = "Hình ảnh đang hiển thị")]
        public string? ShowImages { get; set; }
    }
}