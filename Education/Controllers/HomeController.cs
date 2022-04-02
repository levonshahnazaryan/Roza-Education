using Domain.Helpers;
using Domain.Services;
using Education.Models.Account;
using Education.Models.Home;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

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
                GetUIUsefulLinks = _eduRepository.GetUIUsefulLinks(),
                GetAboutUs = _eduRepository.GetAboutUs()
            });
        }

        [Route("[controller]/AboutCollage")]
        public IActionResult AboutCollage()
        {
            return View("AboutCollage", new AboutCollageVM
            {
                GetAboutCollage = _eduRepository.GetAboutCollage(),
                GetAboutFiles = _eduRepository.GetAboutFiles()
            });
        }

        [Route("[controller]/Education/{*educationsid}")]
        public IActionResult Education(int educationsid = 0)
        {
            return View("Education", new EducationsVM
            {
                GetUIEducation = _eduRepository.GetUIEducation(),
                FindUIEducation = _eduRepository.FindUIEducation(educationsid),
                GetEducationsFile = _eduRepository.GetUIEducationsFile(educationsid)
            });
        }

        [Route("[controller]/Feedback")]
        public IActionResult Feedback()
        {
            return View("Feedback");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/SendFeedback")]
        public IActionResult SendFeedback(string fullName, string email, IFormFile iFile, string content)
        {
            try
            {
                if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(content))
                {
                    SmtpClient smtpClient = new(_appSettings.EmailSettings.Host, _appSettings.EmailSettings.Port)
                    {
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = _appSettings.EmailSettings.EnableSsl,
                        Credentials = new NetworkCredential(_appSettings.EmailSettings.UserName, _appSettings.EmailSettings.PassWord)
                    };
                    MailMessage mail = new()
                    {
                        IsBodyHtml = true,
                        DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure,
                        Subject = "Հետադարձ կապ",
                        Body = "<p>Անուն Ազգանուն՝ " + fullName + "</p><p>Էլ․ հասցե՝ " + email + "</p><p>Հաղորդագրություն՝ " + content + "</p>",
                        From = new MailAddress(_appSettings.EmailSettings.UserName)
                    };
                    if (iFile != null)
                    {
                        using (var stream = iFile.OpenReadStream())
                        {
                            var attachment = new Attachment(stream, iFile.FileName);
                            mail.Attachments.Add(attachment);
                        }
                    }
                    mail.To.Add(new MailAddress(_appSettings.EmailSettings.GetEmail));
                    smtpClient.SendMailAsync(mail);
                    return Json(true);
                }
                return Json(false);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}