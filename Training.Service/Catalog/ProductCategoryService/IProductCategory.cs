using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Data.Entities;
using Training.ViewModel.Catalog.ProductCategoryModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.ProductCategoryService
{
    public interface IProductCategory
    {
        public Task<PageResult<ViewProductCategoryRequest>> GetAllProductCategories();

        public Task<ProductCategory> GetById(int pCateId);

        public Task<PageActionResult> CreateProductCategory(CreateProductCategoryRequest request);

        public Task<PageActionResult> UpdateProductCategory(int pCateId, UpdateProductCategoryRequest request);

        public Task<PageActionResult> DeleteProductCategory(int pCateId);

        public Task<PageActionResult> HideProductCategory(int pCateId);

        public Task<PageActionResult> ShowAtHome(int pCateId);

        public Task<List<ViewProductCategoryRequest>> GetCateClient();
    }
}