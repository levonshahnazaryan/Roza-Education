using Domain.Helpers;
using Domain.Services;
using Education.Models.Account;
using Education.Models.Home;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Education.Controllers
{
    public partial class AccountController : Controller
    {
        private IEduRepasitory _eduRepository;
        private readonly AppSettings _appSettings;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        public AccountController(IEduRepasitory eduRepository, IOptions<AppSettings> appSettings, IWebHostEnvironment webHostEnvironment)
        {
            _eduRepository = eduRepository;
            _appSettings = appSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM userData)
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


        [HttpGet]
        [Route("[controller]/Index")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("[controller]/AboutUs")]
        public ViewResult AboutUs()
        {
            return View("AboutUs", new AboutUsVM
            {
                GetAboutUs = _eduRepository.GetAboutUs()
            });
        }

        [HttpGet]
        [Route("[controller]/AboutCollage")]
        public ViewResult AboutCollage()
        {
            return View("AboutCollage", new AboutCollageVM
            {
                GetAboutCollage = _eduRepository.GetAboutCollage()
            });
        }

        [HttpGet]
        [Route("[controller]/UsefulLinksImage/{usefulLinksId}")]
        public IActionResult UsefulLinksImage(int usefulLinksId)
        {
            var data = _eduRepository.GetUsefulLinks(usefulLinksId);
            return PartialView("_UsefulLinksImage", new UsefulLinksVM
            {
                UsefulLinksId = usefulLinksId,
                Img = data.Img,
                RootUrl = $"/Resources/UsefulLinks/{data.UsefulLinksId}/"
            });
        }

        [HttpGet]
        [Route("[controller]/Education")]
        public ViewResult Education()
        {
            return View("Education");
        }

        [HttpGet]
        [Route("[controller]/EducationContent/{educationsId}")]
        public IActionResult EducationContent(int educationsId)
        {
            var findEducation = _eduRepository.FindEducation(educationsId);
            return PartialView("_EducationContent", new EducationVM
            {
                FindEducation = findEducation
            });
        }

        [HttpGet]
        [Route("[controller]/EducationFile/{educationsId}")]
        public IActionResult EducationFile(int educationsId)
        {
            return PartialView("_EducationFile", new EducationVM
            {
                EducationsId = educationsId
            });
        }

        [HttpGet]
        [Route("[controller]/AboutFile")]
        public IActionResult AboutFile()
        {
            return PartialView("_AboutFile");
        }
    }
}