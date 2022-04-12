using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Data.Entities;
using Training.ViewModel.Catalog.UserModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.UserService
{
    public interface IUserService
    {
        public Task<PageResult<ViewUserRequest>> GetAllUser();

        public Task<User> GetUserById(int id);

        public Task<PageActionResult> Login(string UserName, string Password);

        public Task<PageActionResult> CreateUser(CreateUserRequest request);

        public Task<PageActionResult> UpdateUser(int UserId,UpdateUserRequest request);

        public Task<PageActionResult> DeleteUser(int UserId);

        public Task<PageActionResult> BlockUser(int UserId);
    }
}