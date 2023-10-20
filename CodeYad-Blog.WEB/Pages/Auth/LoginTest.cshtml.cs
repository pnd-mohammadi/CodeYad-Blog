using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CodeYad_Blog.WEB.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginTestModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginTestModel(IUserService userService)
        {
            _userService = userService;
        }
        [Required(ErrorMessage = "نام کاربری را وارد کنید ")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "پسورد را وارد کنید ")]
            [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]

            public string Password { get; set; }
            public void OnGet()
            {

            }

            public IActionResult OnPost()
            {
                if (ModelState.IsValid == false)
                {
                    return Page();
                }
                var user = _userService.LoginUser(new LoginUserDto()
                {
                    UserName = UserName,
                    Password = Password
                });
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Test", "Test"),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(claimPrincipal, properties);
                return RedirectToPage("/Index");
            }

        }
    }
