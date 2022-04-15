using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.Data.Entities;
using Training.ViewModel.Catalog.ProductCategoryModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.ProductCategoryService
{
    public class ProductCategoryService : IProductCategory
    {
        private readonly TrainingDbContext _context;

        public ProductCategoryService(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<PageActionResult> CreateProductCategory(CreateProductCategoryRequest request)
        {
            var CreateProductCategory = (new ProductCategory()
            {
                Banner = request.Banner,
                Name = request.Name,
                ParentId = request.ParentId,
                Show = request.Show,
                Status = request.Status,
            });

            await _context.AddAsync(CreateProductCategory);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Tạo danh mục sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Tạo danh mục sản phẩm thất bại!" };
            }
        }

        public async Task<PageActionResult> DeleteProductCategory(int pCateId)
        {
            var findByid = await _context.ProductCategories.FindAsync(pCateId);
            if (findByid == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Danh mục sản phẩm không tồn tại!" };
            }

            _context.ProductCategories.Remove(findByid);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Xóa danh mục sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Xóa danh mục sản phẩm thất bại!" };
            }
        }

        public async Task<PageResult<ViewProductCategoryRequest>> GetAllProductCategories()
        {
            var getall = await _context.ProductCategories.Select(c => new ViewProductCategoryRequest()
            {
                Id = c.Id,
                Name = c.Name,
                SaleCate = c.SaleCate,
                ParentId = c.ParentId,
                Show = c.Show,
                Status = c.Status,
                ParentName = c.ParentId == 0 ? "Danh mục cha" : _context.ProductCategories.Where(x => x.Id == c.ParentId).Select(x => x.Name).FirstOrDefault()
            }).ToListAsync();

            var actionResult = new PageActionResult { IsSuccess = true, Message = "OK" };

            return new PageResult<ViewProductCategoryRequest> { PageActionResult = actionResult, Items = getall };
        }

        public async Task<ProductCategory> GetById(int pCateId)
        {
            var getById = await _context.ProductCategories.FindAsync(pCateId);

            if (getById == null)
            {
                return null;
            }

            return getById;
        }

        public async Task<PageActionResult> HideProductCategory(int pCateId)
        {
            var findById = await _context.ProductCategories.FindAsync(pCateId);

            if (findById == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Danh mục sản phẩm không tồn tại!" };
            }

            findById.Status = findById.Status == 0 ? 1 : 0;

            _context.ProductCategories.Update(findById);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                if (findById.Status == 1)
                    return new PageActionResult { IsSuccess = true, Message = "Ản danh mục sản phẩm thành công!" };
                return new PageActionResult { IsSuccess = true, Message = "Hiện danh mục sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra, vui lòng thử lại!" };
            }
        }

        public async Task<PageActionResult> ShowAtHome(int pCateId)
        {
            var findById = await _context.ProductCategories.FindAsync(pCateId);

            if (findById == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Danh mục sản phẩm không tồn tại!" };
            }

            findById.Show = findById.Show == 0 ? 1 : 0;

            _context.ProductCategories.Update(findById);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                if (findById.Show == 1)
                    return new PageActionResult { IsSuccess = true, Message = "Ản danh mục ở trang chủ thành công!" };
                return new PageActionResult { IsSuccess = true, Message = "Hiện danh mục ở trang chủ thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra, vui lòng thử lại!" };
            }
        }

        public async Task<List<ViewProductCategoryRequest>> GetCateClient()
        {
            var categories = await _context.ProductCategories.Where(x => x.Status == 0).Select(x => new ViewProductCategoryRequest()
            {
                Id= x.Id,
                Name = x.Name,
                SaleCate = x.SaleCate,
                ParentId = x.ParentId,
            }).ToListAsync();

            return categories;
        }

        public async Task<PageActionResult> UpdateProductCategory(int pCateId, UpdateProductCategoryRequest request)
        {
            var findById = await _context.ProductCategories.FindAsync(pCateId);

            if (findById == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Danh mục sản phẩm không tồn tại!" };
            }

            findById.Status = request.Status;
            findById.Name = request.Name;
            findById.ParentId = request.ParentId;
            findById.Updated_time = DateTime.Now;
            findById.Banner = request.Banner;
            findById.Show = request.Show;
            findById.SaleCate = request.SaleCate;

            _context.ProductCategories.Update(findById);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Cập nhật danh mục sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra, vui lòng thử lại!" };
            }
        }
    }
}