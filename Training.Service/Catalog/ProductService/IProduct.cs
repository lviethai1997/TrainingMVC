﻿using System.Threading.Tasks;
using Training.Data.Entities;
using Training.ViewModel.Catalog.ProductModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.ProductService
{
    public interface IProduct
    {
        Task<PageActionResult> CreateProduct(CreateProductRequest request);

        Task<PageActionResult> UpdateProduct(int id, UpdateProductRequest request);

        Task<PageActionResult> DeleteProduct(int id);

        Task<PageActionResult> HideProduct(int id);

        Task<PageActionResult> ProductHot(int id);

        Task<Product> FindById(int id);

        Task<bool> CountView(int id);

        Task<PageResult<ViewProductRequest>> GetAll();
    }
}