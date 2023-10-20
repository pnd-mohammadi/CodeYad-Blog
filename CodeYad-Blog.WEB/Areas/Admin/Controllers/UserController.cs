using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.WEB.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageId = 1)
        {
           // return View(_userService.GetUserByFilter(pageId,10);
           return View();
        }
    }
}
