using Domain.Helpers;
using Domain.Services;
using Education.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Education.Controllers
{
    public class AccountController : Controller
    {
        private IEduRepasitory _eduRepository;
        private readonly AppSettings _appSettings;
        public AccountController(IEduRepasitory eduRepository, IOptions<AppSettings> appSettings)
        {
            _eduRepository = eduRepository;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Route("[controller]/Index")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/Login")]
        public async Task<IActionResult> Login([FromBody]LoginVM userData)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(userData.UserName) && !string.IsNullOrEmpty(userData.PassWord))
                {
                    if (userData.UserName == _appSettings.UserData.UserName && userData.PassWord == _appSettings.UserData.PassWord)
                    {
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, userData.UserName),
                            new Claim(ClaimTypes.Role, "Administrator")
                        };

                        var id = new ClaimsIdentity(claims, "Forms");
                        var principal = new ClaimsPrincipal(id);
                        if (null != principal)
                        {
                            await HttpContext.SignInAsync(
                            "AuthEduAppCookie",
                            principal,
                            new AuthenticationProperties
                            {
                                IsPersistent = true
                            });
                        }
                        return Json(new { isAuthorized = true, errorText = "" });
                    }
                }
            }
            return Json(new { isAuthorized = false, errorText = "Սխալ ծածկանուն կամ ծածկագիր" });
        }

        [HttpGet]
        [Route("[controller]/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AuthEduAppCookie");
            return RedirectToAction("Index", "Home", null);
        }
    }
}
