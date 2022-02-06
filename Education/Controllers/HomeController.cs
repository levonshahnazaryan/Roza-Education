using Domain.Helpers;
using Domain.Services;
using Education.Models.Home;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Education.Controllers
{
    public class HomeController : Controller
    {
        private IEduRepasitory _eduRepository;
        private readonly AppSettings _appSettings;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IEduRepasitory eduRepository, IOptions<AppSettings> appSettings, IWebHostEnvironment webHostEnvironment)
        {
            _eduRepository = eduRepository;
            _appSettings = appSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View("Index", new IndexVM
            {
                GetUIUsefulLinks = _eduRepository.GetUIUsefulLinks()
            });
        }
    }
}
