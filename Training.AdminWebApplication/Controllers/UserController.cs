using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Service.Catalog.UserService;
using Training.ViewModel.Catalog.UserModel;

namespace Training.AdminWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly INotyfService _notyfService;

        public UserController(IUserService userService, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _userService = userService;
        }

        [Route("/listUser")]
        public async Task<IActionResult> Index()
        {
            var GetAllUser = await _userService.GetAllUser();

            //if (GetAllUser.PageActionResult.IsSuccess == true)
            //{
            //    _notyfService.Success(GetAllUser.PageActionResult.Message);
            //}

            return View(GetAllUser);
        }

        [Route("/createUser", Name = "createUser")]
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [Route("/createUser", Name = "createUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var CreateUser = await _userService.CreateUser(request);

            if (CreateUser.IsSuccess == true)
            {
                _notyfService.Success(CreateUser.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(CreateUser.Message);
                return View(request);
            }
        }

        [Route("/UpdateUser.{UserId}", Name = "UpdateUser")]
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int UserId)
        {
            var findUser = await _userService.GetUserById(UserId);

            var user = new UpdateUserRequest()
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Email = findUser.Email,
                Phone = findUser.Phone,
                Address = findUser.Address,
                Username = findUser.Username,
                Password = "",
                Role = findUser.Role,
                Status = findUser.Status,
                Created_time = findUser.Created_time,
                Updated_time = findUser.Updated_time
            };

            return View(user);
        }

        [Route("/UpdateUser.{UserId}", Name = "UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(int UserId, UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var updateUser = await _userService.UpdateUser(UserId, request);
            if (updateUser.IsSuccess == true)
            {
                _notyfService.Success(updateUser.Message);
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(updateUser.Message);
                return View(request);
            }
        }

        [Route("DelUsr/{UserId}", Name = "DelUsr")]
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var Deluser = await _userService.DeleteUser(UserId);

            if (Deluser.IsSuccess == true)
            {
                _notyfService.Success(Deluser.Message);
            }
            else
            {
                _notyfService.Error(Deluser.Message);
            }

            return RedirectToAction("Index");
        }

        [Route("BlockUser/{UserId}",Name = "BlockUser")]
        [HttpGet]
        public async Task<IActionResult> BlockUser(int UserId)
        {
            var BlockUser = await _userService.BlockUser(UserId);

            if (BlockUser.IsSuccess == true)
            {
                _notyfService.Success(BlockUser.Message);
            }
            else
            {
                _notyfService.Error(BlockUser.Message);
            }

            return RedirectToAction("Index");
        }
    }
}