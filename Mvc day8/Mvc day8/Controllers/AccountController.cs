using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mvc_day8.Models;
using Mvc_day8.ViewModels;

namespace Mvc_day8.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new();
                user.Firstname = model.FirstName;
                user.Lastname = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.PasswordHash = model.Password;
                var result = await UserManager.CreateAsync(user , model.Password) ;
                if(result.Succeeded)
                {
                    //createcookie
                    await SignInManager.SignInAsync(user , isPersistent: true );
                    return RedirectToAction("Index" , "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }


            return View(model);
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Username);
                if(user !=null)
                {
                    var found = await UserManager.CheckPasswordAsync(user , model.Password);
                    if(found)
                    {
                        await SignInManager.SignInAsync(user , model.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            ModelState.AddModelError("" , "Wrong Username or password..");
            return View(model);
        }








        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Index" , "Home");
        }
    }
}
