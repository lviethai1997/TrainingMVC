using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.Data.Entities;
using Training.ViewModel.Catalog.UserModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.UserService
{
    public class UserService : IUserService
    {
        private readonly TrainingDbContext _context;

        public UserService(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<PageActionResult> BlockUser(int UserId)
        {
            var findUser = await _context.Users.FindAsync(UserId);

            if (findUser == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Tài khoản không tồn tại!" };
            }

            findUser.Status = findUser.Status == 0 ? 1 : 0;

            _context.Users.Update(findUser);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                if (findUser.Status == 1)
                    return new PageActionResult { IsSuccess = true, Message = "Khoá tài khoản thành công" };
                return new PageActionResult { IsSuccess = true, Message = "Mở khoá tài khoản thành công" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Khóa tài khoản thất bại" };
            }
        }

        public async Task<PageActionResult> CreateUser(CreateUserRequest request)
        {
            var CreateUser = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Password = GetMD5(request.Password),
                Phone = request.Phone,
                Username = request.Username,
                Role = request.Role,
                Status = request.Status,
            };

            await _context.Users.AddAsync(CreateUser);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Thêm mới người dùng thành công" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Thêm mới người dùng thất bại" };
            }
        }

        public async Task<PageActionResult> DeleteUser(int UserId)
        {
            var findUser = await _context.Users.FindAsync(UserId);

            if (findUser == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Tài khoản không tồn tại!" };
            }

            _context.Users.Remove(findUser);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Xóa tài khoản thành công" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Xóa tài khoản thất bại" };
            }
        }

        public async Task<PageResult<ViewUserRequest>> GetAllUser()
        {
            var GetAllUser = await _context.Users.Select(x => new ViewUserRequest()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                Role = x.Role,
                Status = x.Status
            }).ToListAsync();

            var ActionResult = new PageActionResult { IsSuccess = true, Message = "Lấy dữ liệu thành công!" };

            return new PageResult<ViewUserRequest> { PageActionResult = ActionResult, Items = GetAllUser };
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Task<PageActionResult> Login(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<PageActionResult> UpdateUser(int UserId,UpdateUserRequest request)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(x=>x.Id==UserId);

            if (findUser == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Tài khoản không tồn tại!" };
            }

            findUser.Name = request.Name;
            if (request.Password != null)
            {
                findUser.Password = GetMD5(request.Password);
            }
            findUser.Phone = request.Phone;
            findUser.Address = request.Address;
            findUser.Role = request.Role;
            findUser.Status = request.Status;

            findUser.Updated_time = DateTime.Now;

            _context.Users.Update(findUser);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Thêm mới người dùng thành công" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Thêm mới người dùng thất bại" };
            }
        }

        private string GetMD5(string str)
        {
            string str_md5_out = string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes_md5_in = Encoding.UTF8.GetBytes(str);
                byte[] bytes_md5_out = md5.ComputeHash(bytes_md5_in);

                str_md5_out = BitConverter.ToString(bytes_md5_out);
                str_md5_out = str_md5_out.Replace("-", "");
            }
            return str_md5_out;
        }
    }
}