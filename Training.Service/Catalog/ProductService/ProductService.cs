using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
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
                await _storageService.DeleteFileAsync(findByid.Thunbar);
                findByid.Thunbar = await this.SaveFile(request.Thunbar);
            }

            if (request.Images != null)
            {
                foreach (var image in findByid.Images.Split(','))
                {
                    await _storageService.DeleteFileAsync(image);
                }

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

            if (product == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Sản phẩm không tồn tại!" };
            }

            await _storageService.DeleteFileAsync(product.Thunbar);

            foreach (var item in product.Images.Split(","))
            {
                await _storageService.DeleteFileAsync(item);
            }

            _context.Products.Remove(product);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Xóa sản phẩm thành công!" };
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
                CategoryName =  _context.ProductCategories.Where(c => c.Id == x.CategoryId).Select(c => c.Name).FirstOrDefault(),
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
    }
}