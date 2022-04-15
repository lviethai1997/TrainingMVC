using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.Data.Entities;
using Training.Service.Common;
using Training.ViewModel.Catalog.ProductModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.ProductService
{
    public class ProductService : IProduct
    {
        private readonly TrainingDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(TrainingDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<PageActionResult> CreateProduct(CreateProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                PriceIn = request.PriceIn,
                Sale = request.Sale,
                CategoryId = request.CategoryId,
                Content = request.Content,
                Quantity = request.Quantity,
                ViewCount = 0,
                Hot = request.Hot,
                Status = request.Status,
                Thunbar = await this.SaveFile(request.Thunbar),
            };

            string images = "";
            foreach (var image in request.Images)
            {
                images += await this.SaveFile(image) + ",";
            }

            product.Images = images.Remove(images.Length - 1);

            await _context.Products.AddAsync(product);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Tạo mới sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Tạo mới sản phẩm thất bại!" };
            }
        }

        public async Task<PageActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            var findByid = await _context.Products.FindAsync(id);

            if (findByid == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Sản phẩm không tồn tại!" };
            }

            findByid.Name = request.Name;
            findByid.Price = request.Price;
            findByid.PriceIn = request.PriceIn;
            findByid.Sale = request.Sale;
            findByid.CategoryId = request.CategoryId;
            findByid.Content = request.Content;
            findByid.Quantity = request.Quantity;
            findByid.ViewCount = 0;
            findByid.Hot = request.Hot;
            findByid.Status = request.Status;

            if (request.Thunbar != null)
            {
                findByid.Thunbar = await this.SaveFile(request.Thunbar);
            }

            if (request.Images != null)
            {
                string images = "";
                foreach (var image in request.Images)
                {
                    images += await this.SaveFile(image) + ",";
                }
                findByid.Images = images.Remove(images.Length - 1);
            }

            _context.Products.Update(findByid);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Tạo mới sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Tạo mới sản phẩm thất bại!" };
            }
        }

        public async Task<PageActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            await _storageService.DeleteFileAsync(product.Thunbar);

            foreach (var item in product.Images.Split(","))
            {
                await _storageService.DeleteFileAsync(item);
            }

            _context.Remove(product);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Xoá sản phẩm thành công!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Xóa sản phẩm thất bại!" };
            }
        }

        public Task<PageActionResult> HideProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageActionResult> ProductHot(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<PageResult<ViewProductRequest>> GetAll()
        {
            var products = await _context.Products.Select(x => new ViewProductRequest()
            {
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                PriceIn = x.PriceIn,
                Sale = x.Sale,
                Thunbar = x.Thunbar,
                CategoryId = x.CategoryId,
                CategoryName = _context.ProductCategories.Where(c => c.Id == x.CategoryId).Select(c => c.Name).FirstOrDefault(),
                Quantity = x.Quantity,
                ViewCount = x.ViewCount,
                Hot = x.Hot,
                Status = x.Status,
            }).ToListAsync();

            var actionResult = new PageActionResult { IsSuccess = true, Message = "OK" };

            return new PageResult<ViewProductRequest> { PageActionResult = actionResult, Items = products };
        }

        public async Task<bool> CountView(int id)
        {
            var product = await _context.Products.FindAsync(id);

            product.ViewCount += 1;
            _context.Products.Update(product);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PageResult<ViewProductRequest>> GetAllPaging(PagingRequest request)
        {
            var query = await _context.Products.Select(x => new ViewProductRequest()
            {
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                PriceIn = x.PriceIn,
                Sale = x.Sale,
                Thunbar = x.Thunbar,
                CategoryId = x.CategoryId,
                CategoryName = _context.ProductCategories.Where(c => c.Id == x.CategoryId).Select(c => c.Name).FirstOrDefault(),
                Quantity = x.Quantity,
                ViewCount = x.ViewCount,
                Hot = x.Hot,
                Status = x.Status,
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(request.Keyword.ToLower()) || x.Id.ToString().Contains(request.Keyword)).ToList();
            }

            if (request.idCate != null)
            {
                query = query.Where(x => x.CategoryId == Convert.ToInt32(request.idCate)).ToList();
            }

            var totalCount = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);

            var page = new PageResult<ViewProductRequest>
            {
                Items = data.ToList(),
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalCount,
            };

            return page;
        }

        public async Task<List<ViewProductRequest>> GetProductForClient()
        {
            var products = await _context.Products.Where(x => x.Status == 0).Select(x => new ViewProductRequest()
            {
                Name = x.Name,
                Id = x.Id,
                Images = x.Images,
                Price = x.Price,
                Sale = x.Sale,
                Thunbar = x.Thunbar,
                Quantity = x.Quantity,
                Hot = x.Hot,
            }).ToListAsync();

            return products;
        }

        public async Task<PageResult<ViewProductRequest>> GetProductByCategory(int CategoryId, PagingRequest request)
        {
            var getAll = from p in _context.Products
                         join cate in _context.ProductCategories
                         on p.CategoryId equals cate.Id
                         where p.Status == 0 && cate.Status == 0
                         select new { p, cate };

            var getParentId = await _context.ProductCategories.Where(x => x.ParentId == CategoryId).Select(x => x.Id).ToListAsync();

            if (getParentId.Count == 0)
            {
                getAll = getAll.Where(x => x.cate.Id == CategoryId);
            }
            else
            {
                getAll = getAll.Where(x => getParentId.Contains(x.p.CategoryId) || x.p.CategoryId == CategoryId);
            }

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                getAll = getAll.Where(x => x.p.Name.ToLower().Contains(request.Keyword.ToLower()));
            }

            var totalCount = await getAll.CountAsync();

            var data = await getAll.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ViewProductRequest()
            {
                CategoryName = x.cate.Name,
                CategoryId = x.cate.Id,
                Name = x.p.Name,
                Id = x.p.Id,
                Images = x.p.Images,
                Price = x.p.Price,
                Sale = x.p.Sale,
                Thunbar = x.p.Thunbar,
                Quantity = x.p.Quantity,
                Hot = x.p.Hot,
            }).ToListAsync();

            var result = new PageActionResult()
            {
                IsSuccess = true,
                Message = "ok"
            };

            var page = new PageResult<ViewProductRequest>
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalCount,
                PageActionResult = result
            };

            return page;
        }

        public async Task<IndexClientViewModel> GetIndexClientProducts()
        {
            var products = from product in _context.Products
                           join category in _context.ProductCategories
                           on product.CategoryId equals category.Id
                           where product.Status == 0 && category.Status == 0 && product.Quantity > 0
                           select (new { product, category });

            var featuredProducts = await products.Where(x => x.product.Hot == 0).Take(10).OrderByDescending(x => x.product.Updated_time).Select(x => new ViewProductRequest
            {
                Id = x.product.Id,
                Name = x.product.Name,
                Price = x.product.Price,
                Sale = x.product.Sale,
                Thunbar = x.product.Thunbar,
                Images = x.product.Images,
                CategoryId = x.product.CategoryId,
                CategoryName = x.category.Name,
                Quantity = x.product.Quantity,
                ViewCount = x.product.ViewCount,
                Hot = x.product.Hot,
                Status = x.product.Status
            }).ToListAsync();

            var saleProducts = await products.Where(x => x.product.Sale > 0).Take(10).OrderByDescending(x => x.product.Updated_time).OrderByDescending(x => x.product.Sale).Select(x => new ViewProductRequest
            {
                Id = x.product.Id,
                Name = x.product.Name,
                Price = x.product.Price,
                Sale = x.product.Sale,
                Thunbar = x.product.Thunbar,
                Images = x.product.Images,
                CategoryId = x.product.CategoryId,
                CategoryName = x.category.Name,
                Quantity = x.product.Quantity,
                ViewCount = x.product.ViewCount,
                Hot = x.product.Hot,
                Status = x.product.Status
            }).ToListAsync();

            var newProducts = await products.Take(10).OrderByDescending(x => x.product.Updated_time).OrderByDescending(x => x.product.Id).Select(x => new ViewProductRequest
            {
                Id = x.product.Id,
                Name = x.product.Name,
                Price = x.product.Price,
                Sale = x.product.Sale,
                Thunbar = x.product.Thunbar,
                Images = x.product.Images,
                CategoryId = x.product.CategoryId,
                CategoryName = x.category.Name,
                Quantity = x.product.Quantity,
                ViewCount = x.product.ViewCount,
                Hot = x.product.Hot,
                Status = x.product.Status
            }).ToListAsync();

            var topViewProducts = await products.Where(x => x.product.ViewCount > 0).Take(10).OrderByDescending(x => x.product.ViewCount).OrderByDescending(x => x.product.Updated_time).Select(x => new ViewProductRequest
            {
                Id = x.product.Id,
                Name = x.product.Name,
                Price = x.product.Price,
                Sale = x.product.Sale,
                Thunbar = x.product.Thunbar,
                Images = x.product.Images,
                CategoryId = x.product.CategoryId,
                CategoryName = x.category.Name,
                Quantity = x.product.Quantity,
                ViewCount = x.product.ViewCount,
                Hot = x.product.Hot,
                Status = x.product.Status
            }).ToListAsync();

            var topSaleProducts = await products.Where(x => x.product.Sold > 0).Take(10).OrderByDescending(x => x.product.Sold).OrderByDescending(x => x.product.Updated_time).Select(x => new ViewProductRequest
            {
                Id = x.product.Id,
                Name = x.product.Name,
                Price = x.product.Price,
                Sale = x.product.Sale,
                Thunbar = x.product.Thunbar,
                Images = x.product.Images,
                CategoryId = x.product.CategoryId,
                CategoryName = x.category.Name,
                Quantity = x.product.Quantity,
                ViewCount = x.product.ViewCount,
                Hot = x.product.Hot,
                Status = x.product.Status
            }).ToListAsync();

            var reuslt = new IndexClientViewModel()
            {
                TopSaleProducts = topSaleProducts,
                TopViewProducts = topViewProducts,
                FeaturedProducts = featuredProducts,
                SaleProducts = saleProducts,
                NewProducts = newProducts
            };

            return reuslt;
        }
    }
}